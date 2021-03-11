using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// The Time struct describes a point in time.
    /// </summary>
    /// <remarks>
    /// This struct can compare points in time, show them and add or substract to each other or to the TimePeriod struct.
    /// </remarks>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        ///<value>Gets number of hours in Time struct</value>
        public byte Hours { get { return _Hours; } }
        private readonly byte _Hours;

        ///<value>Gets number of minutes in Time struct</value>
        public byte Minutes { get { return _Minutes; } }
        private readonly byte _Minutes;

        ///<value>Gets number of seconds in Time struct</value>
        public byte Seconds { get { return _Seconds; } }
        private readonly byte _Seconds;

        /// <summary>
        /// Correct range of input values is 00:00:00 … 23:59:59. Other input value will cause ArgumentOutOfRangeException to be thrown.
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentOutOfRangeException();
            if (minutes < 0 || minutes > 59)
                throw new ArgumentOutOfRangeException();
            if (seconds < 0 || seconds > 59)
                throw new ArgumentOutOfRangeException();

            _Hours = hours;
            _Minutes = minutes;
            _Seconds = seconds;
        }

        /// <summary>
        /// Correct range of input values is 00:00:00 … 23:59:59. Other input value will cause ArgumentOutOfRangeException to be thrown.
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        public Time(byte hours, byte minutes) : this(hours, minutes, 00) { }

        /// <summary>
        /// Correct range of input values is 00:00:00 … 23:59:59. Other input value will cause ArgumentOutOfRangeException to be thrown.
        /// </summary>
        /// <param name="hours"></param>
        public Time(byte hours) : this(hours, 00, 00) { }

        /// <summary>
        /// Initializes the hours, minutes and seconds values from the string argument.
        /// </summary>
        /// <exception cref="System.FormatException">
        /// Thrown when parameter is not formatted like "hh:mm:ss" and is not in the range of 00:00:00 … 23:59:59.
        /// </exception>
        /// <param name="hms"></param>
        public Time(string hms)
        {
            string[] arr = hms.Split(':');

            _Hours = 0;
            _Minutes = 0;
            _Seconds = 0;

            if (!hms.Contains(":") || string.IsNullOrEmpty(hms) || arr.Length != 3)
            {
                throw new FormatException("The required format is hh:mm:ss");
            }

            bool flagH = int.TryParse(arr[0], out int h);
            bool flagM = int.TryParse(arr[1], out int m);
            bool flagS = int.TryParse(arr[2], out int s);

            if( flagH && flagM && flagS)
            {
                if(h >= 0 && h <= 23 && m >= 0 && m<= 59 && s >= 0 && s <= 59)
                {
                    _Hours = (byte)h;
                    _Minutes = (byte)m;
                    _Seconds = (byte)s;
                }
                else
                    throw new FormatException("The required range is 00:00:00 … 23:59:59");
            }
            else
                new FormatException("The required range is 00:00:00 … 23:59:59");
        }

        /// <summary>
        /// Formats point in time to form "hh:mm:ss" 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{_Hours:D2}:{_Minutes:D2}:{_Seconds:D2}";

        public bool Equals(Time other)
        {
            return _Hours == other._Hours &&
                    _Minutes == other._Minutes &&
                    _Seconds == other._Seconds;
        }

    public override bool Equals(object obj)
        {
            return obj is Time equatable && Equals(equatable);
        }

        public override int GetHashCode() => (_Hours, _Minutes, _Seconds).GetHashCode();
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }

        /// <summary>
        /// Substract two point of Time and returns the result.
        /// </summary>
        /// <returns>
        /// Returns the result of the subtraction of two points in time.
        /// </returns>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static Time operator -(Time t1, Time t2)
        {
            Time time;

            var hour = Math.Abs((t1._Hours - t2._Hours) % 24);
            var minutes = Math.Abs((t1._Minutes - t2._Minutes) % 60);
            var seconds = Math.Abs(t1._Seconds - t2._Seconds);

            time = new Time((byte)hour, (byte)minutes, (byte)seconds);

            return time;
        }

        public int getSecondsDifference(Time t1)
        {
            int totalSeconds = 0;

            var h = Hours - t1.Hours;
            var m = Minutes - t1.Minutes;
            var s = Seconds - t1.Seconds;

            if (h != 0)
                totalSeconds += (h * 3600);
            if (m != 0)
                totalSeconds += (m * 60);
            if (s != 0)
                totalSeconds += s;

            return totalSeconds;
        }

        public int CompareTo(Time obj)
        {
            var h = Hours - obj.Hours;
            var m = Minutes - obj.Minutes;
            var s = Seconds - obj.Seconds;

            if (h < 0 || m < 0 || s <0)
                return -1;
            else if (h > 0 || m > 0 || s > 0)
                return 1;
            else
                return 0;
        }

        public static bool operator >(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == 1;
        }

        public static bool operator <(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == -1;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) >= 0;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) <= 0;
        }

        public Time PlusTimePeriod(TimePeriod t1)
        {
            Time time;

            var TimePeriodHours = (t1.Seconds / 3600); 
            var TimePeriodMinutes = (t1.Seconds % 3600) / 60;
            var TimePeriodSeconds = t1.Seconds % 60;

            var hour = (TimePeriodHours + Hours);
            var minutes = (TimePeriodMinutes + Minutes);
            var seconds = TimePeriodSeconds + Seconds;

            time = new Time((byte)hour, (byte)minutes, (byte)seconds);

            return time;
        }

        public static Time Plus(Time t1, TimePeriod t2)
        {
            return t1.PlusTimePeriod(t2);
        }

        public static Time operator +(Time t1, TimePeriod t2)
        {
            return t1.PlusTimePeriod(t2);
        }

    }
}

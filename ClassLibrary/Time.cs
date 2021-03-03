using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours < 0 || hours > 24)
                throw new ArgumentOutOfRangeException();
            if (minutes < 0 || minutes > 60)
                throw new ArgumentOutOfRangeException();
            if (seconds < 0 || seconds > 60)
                throw new ArgumentOutOfRangeException();

            _Hours = hours;
            _Minutes = minutes;
            _Seconds = seconds;
        }

        public Time(byte hours, byte minutes) : this(hours, minutes, 00) { }
        public Time(byte hours) : this(hours, 00, 00) { }
        public Time(string hms)
        {
            string[] arr = hms.Split(':');

            this._Hours = Convert.ToByte(arr[0]);
            this._Minutes = Convert.ToByte(arr[1]);
            this._Seconds = Convert.ToByte(arr[2]);
        }

        public byte Hours { get { return _Hours; } }
        private readonly byte _Hours;
        public byte Minutes { get { return _Minutes; } }
        private readonly byte _Minutes;
        public byte Seconds { get { return _Seconds; } }
        private readonly byte _Seconds;

        public override string ToString() => $"{_Hours}:{_Minutes}:{_Seconds}";

        public bool Equals(Time other)
        {
            return Hours == other.Hours &&
                    Minutes == other.Minutes &&
                    Seconds == other.Seconds;
        }

        public override bool Equals(object obj)
        {
            return obj is Time equatable && Equals(equatable);
        }

        public override int GetHashCode()
        {
            return _Hours.GetHashCode() + _Minutes.GetHashCode() + _Seconds.GetHashCode();
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }

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

            return totalSeconds + s;
        }

        public int CompareTo(Time obj)
        {
            return getSecondsDifference(obj);
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

        public Time Plus(TimePeriod t1)
        {
            Time time;

            var TimePeriodHours = (t1.Seconds / 3600);
            var TimePeriodMinutes = (t1.Seconds - TimePeriodHours) / 60;
            var TimePeriodSeconds = t1.Seconds % 60;

            var hour = (TimePeriodHours + Hours) % 24;
            var minutes = (TimePeriodMinutes + Minutes) % 60;
            var seconds = TimePeriodSeconds + Seconds;

            time = new Time((byte)hour, (byte)minutes, (byte)seconds);

            return time;
        }

        public static Time Plus(Time t1, TimePeriod t2)
        {
            Time time;

            var TimePeriodHours = t2.Seconds / 3600;
            var TimePeriodMinutes = (t2.Seconds - TimePeriodHours) / 60;
            var TimePeriodSeconds = t2.Seconds % 60;

            var hour = (t1.Hours + TimePeriodHours) % 24;
            var minutes = (t1.Minutes + TimePeriodMinutes) % 60;
            var seconds = t1.Seconds + TimePeriodSeconds;

            time = new Time((byte)hour, (byte)minutes, (byte)seconds);

            return time;
        }

        public static Time operator +(Time t1, TimePeriod t2)
        {
            Time time;

            var TimePeriodHours = t2.Seconds / 3600;
            var TimePeriodMinutes = (t2.Seconds - TimePeriodHours) / 60;
            var TimePeriodSeconds = t2.Seconds % 60;

            var hour = (t1.Hours + TimePeriodHours) % 24;
            var minutes = (t1.Minutes + TimePeriodMinutes) % 60;
            var seconds = t1.Seconds + TimePeriodSeconds;

            time = new Time((byte)hour, (byte)minutes, (byte)seconds);

            return time;
        }

    }
}

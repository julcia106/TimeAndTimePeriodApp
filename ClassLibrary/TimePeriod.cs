using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// The TimePeriod struct represents the length of the period in time, the distance between two points in time.
    /// </summary>
    /// <remarks>
    /// This struct can compare  time periods, show them and add or substract to each other or to the Time struct.
    /// </remarks>
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        ///<value>Gets number of seconds in TimePeriod struct</value>
        public long Seconds { get { return _Seconds; } }
        private readonly long _Seconds;
        public TimePeriod(long seconds)
        {
            if (seconds < 0)
                throw new ArgumentOutOfRangeException("The seconds value must be greater than 0.");
            _Seconds = seconds;
        }

        public TimePeriod(int hours, int minutes, int seconds)
        {
            _Seconds = (hours * 3600) + (minutes * 60) + seconds;
        }

        public TimePeriod(int hours, int minutes)
        {
            _Seconds = (hours * 3600) + (minutes * 60);
        }

        public TimePeriod(Time t1, Time t2)
        {

            _Seconds = Math.Abs(t1.getSecondsDifference(t2));
        }

        public TimePeriod(string hms)
        {
            string[] arr = hms.Split(':');

            _Seconds = 0;

            if (!hms.Contains(":") || string.IsNullOrEmpty(hms) || arr.Length != 3)
            {
                throw new FormatException("The required format is hh:mm:ss");
            }

            bool flagH = int.TryParse(arr[0], out int h);
            bool flagM = int.TryParse(arr[1], out int m);
            bool flagS = int.TryParse(arr[2], out int s);

            if(flagH && flagM && flagS)
            {
                if (h >= 0 && m >= 0 && s >= 0)
                {
                    _Seconds = (h * 3600) + (m * 60) + s;
                }
                else
                    throw new FormatException("Values must be greater than 0");
            }
            else
                throw new FormatException("Values must be greater than 0");
        }

        public bool Equals(TimePeriod other)
        {
            return Seconds == other.Seconds;
        }

        public override bool Equals(object obj)
        {
            return obj is Time equatable && Equals(equatable);
        }

        public override int GetHashCode() => (int)_Seconds.GetHashCode();
        public int CompareTo(TimePeriod other)
        {
            return (int)(this.Seconds - other.Seconds);
        }

        public static bool operator <(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(TimePeriod t1, TimePeriod t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(TimePeriod t1, TimePeriod t2)
        {
            return !(t1 == t2);
        }

        public override string ToString()
        {
            long hours = Seconds / 3600;
            long minutes = (Seconds / 60) % 60;
            long seconds = Seconds % 60;

            return ($"{hours:D2}:{minutes:D2}:{seconds:D2}");
        }

        public TimePeriod Plus(TimePeriod t1)
        {
            TimePeriod timePeriod;

            var SumSeconds = this.Seconds + t1.Seconds;

            timePeriod = new TimePeriod(SumSeconds);
            return timePeriod;
        }

        public static TimePeriod Plus(TimePeriod t1, TimePeriod t2)
        {
            TimePeriod timePeriod;

            var SumSeconds = t1.Seconds + t2.Seconds;

            timePeriod = new TimePeriod(SumSeconds);
            return timePeriod;
        }

        public static TimePeriod operator +(TimePeriod t1, TimePeriod t2)
        {

            TimePeriod timePeriod;

            var SumSeconds = t1.Seconds + t2.Seconds;

            timePeriod = new TimePeriod(SumSeconds);
            return timePeriod;
        }
    }
}

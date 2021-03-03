using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public TimePeriod(long seconds)
        {
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


            int hours = Convert.ToInt32(arr[0]);
            int minutes = Convert.ToInt32(arr[1]);
            int seconds = Convert.ToInt32(arr[2]);

            _Seconds = (hours * 3600) + (minutes * 60) + seconds;
        }


        public long Seconds { get { return _Seconds; } }
        private readonly long _Seconds;

        public bool Equals(TimePeriod other)
        {
            return Seconds == other.Seconds;
        }

        public override bool Equals(object obj)
        {
            return obj is Time equatable && Equals(equatable);
        }

        public override int GetHashCode()
        {
            return (int)_Seconds;
        }

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
            long minutes = (Seconds - hours) / 60;
            long seconds = Seconds % minutes;

            return ($"{hours}:{minutes}:{seconds}");
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

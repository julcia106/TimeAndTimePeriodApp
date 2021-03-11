using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class TimeTests
    {
        [DataTestMethod]
        [DataRow((byte)30)]
        [DataRow((byte)25)]
        [DataRow(byte.MaxValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Time_Constructor_Hours_Wrong_Value(byte input)
        {
            Time time = new Time(input); 
        }

        [DataTestMethod]
        [DataRow((byte)12, (byte)12)]
        [DataRow((byte)22, (byte)22)]
        [DataRow((byte)3, (byte)3)]
        public void Time_Constructor_Hours_Correct_Value(byte input, byte expected)
        {
            Time time = new Time(input);
            Assert.AreEqual(time.Hours, expected);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)0, (byte)23, (byte)0)]
        [DataRow((byte)0, (byte)1, (byte)0, (byte)1)]
        [DataRow((byte)11, (byte)1, (byte)11, (byte)1)]
        [DataRow((byte)3, (byte)10, (byte)3, (byte)10)]
        public void Time_Constructor_Hours_Minutes_Correct_Value(byte h, byte m, byte expectedHours, byte expectedMinutes)
        {
            Time time = new Time(h, m);
            Assert.AreEqual(time.Hours, expectedHours);
            Assert.AreEqual(time.Minutes, expectedMinutes);
        }

        [DataTestMethod]
        [DataRow((byte)24, (byte)61)]
        [DataRow((byte)25, (byte)60)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Time_Constructor_Hours_Minutes_Wrong_Values(byte h, byte m)
        {
            Time time = new Time(h, m);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)0, (byte)23, (byte)23, (byte)0, (byte)23)]
        [DataRow((byte)0, (byte)1, (byte)3, (byte)0, (byte)1, (byte)3)]
        [DataRow((byte)11, (byte)1, (byte)11, (byte)11, (byte)1, (byte)11)]
        [DataRow((byte)3, (byte)10, (byte)53, (byte)3, (byte)10, (byte)53)]
        public void Time_Constructor_Hours_Minutes_Seconds_Correct_Value(byte h, byte m, byte s, byte expectedHours, byte expectedMinutes, byte expectedSeconds)
        {
            Time time = new Time(h, m, s);
            Assert.AreEqual(time.Hours, expectedHours);
            Assert.AreEqual(time.Minutes, expectedMinutes);
            Assert.AreEqual(time.Seconds, expectedSeconds);
        }

        [DataTestMethod]
        [DataRow((byte)24, (byte)61, (byte)61)]
        [DataRow((byte)25, (byte)60, (byte)77)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Time_Constructor_Hours_Minutes_Seconds_Wrong_Values(byte h, byte m, byte s)
        {
            Time time = new Time(h, m, s);
        }

        [DataTestMethod]
        [DataRow("0:0:0")]
        [DataRow("00:00:00")]
        [DataRow("13:13:13")]
        [DataRow("1:00:59")]
        [DataRow("23:59:59")]
        public void Time_String_Constructor_Corrent(string str)
        {
            Time time = new Time(str);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("abcde")]
        [DataRow("15:5::")]
        [DataRow("3:5")]
        [DataRow("24:59:59")]
        [DataRow("25:60:60")]
        [ExpectedException(typeof(FormatException))]
        public void Time_String_Constructor_Wrong(string str)
        {
            Time time = new Time(str);
        }

        [DataTestMethod]
        [DataRow((byte)22, (byte)44, (byte)54, "22:44:54")]
        [DataRow((byte)4, (byte)1, (byte)5, "04:01:05")]
        [DataRow((byte)23, (byte)59, (byte)59, "23:59:59")]
        [DataRow((byte)1, (byte)1, (byte)1, "01:01:01")]
        public void To_String_Method(byte h, byte m, byte s, string expected)
        {
            Time time = new Time(h, m, s);
            Assert.AreEqual(time.ToString(), expected);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)2, (byte)3, (byte)1, (byte)2, (byte)2)]
        [DataRow((byte)12, (byte)13, (byte)14, (byte)11, (byte)12, (byte)13)]
        [DataRow((byte)5, (byte)0, (byte)0, (byte)3, (byte)0, (byte)0)]
        [DataRow((byte)4, (byte)33, (byte)23, (byte)4, (byte)32, (byte)23)]
        public void Greater_Than_Operator(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time time = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, time > time2);
        }

        [DataTestMethod]
        [DataRow((byte)3, (byte)57, (byte)56, (byte)23, (byte)58, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)0, (byte)2, (byte)0, (byte)0)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)10)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)23, (byte)1, (byte)2)]
        public void Less_Than_Operator(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time time = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);

            Assert.AreEqual(true, time < time2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)56, (byte)23, (byte)56, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)2)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)20, (byte)0, (byte)0)]
        public void Greater_Or_Equal_Than_Operator(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time time = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, time >= time2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)56, (byte)56, (byte)23, (byte)56, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)2, (byte)3)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)2)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)22, (byte)3, (byte)1)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)20, (byte)1, (byte)1)]
        public void Less_Or_Equal_Than_Operator(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time time = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, time <= time2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)56, (byte)56, (byte)23, (byte)56, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)1)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)2)]
        [DataRow((byte)22, (byte)3, (byte)1, (byte)22, (byte)3, (byte)1)]
        [DataRow((byte)20, (byte)1, (byte)1, (byte)20, (byte)1, (byte)1)]
        public void Equal_Operator(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time time = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, time == time2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)56, (byte)23, (byte)56, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)34, (byte)2)]
        [DataRow((byte)20, (byte)2, (byte)3, (byte)20, (byte)0, (byte)0)]
        public void Not_Equal_Operator(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time time = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, time != time2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)56, (byte)56, (byte)23, (byte)56, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)1)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)2)]
        [DataRow((byte)22, (byte)3, (byte)1, (byte)22, (byte)3, (byte)1)]
        [DataRow((byte)20, (byte)1, (byte)1, (byte)20, (byte)1, (byte)1)]
        public void Equals_Method(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time time = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, time.Equals(time2));
        }

        [DataTestMethod]
        [DataRow((byte)0, (byte)0, (byte)0, "00:00:00")]
        [DataRow((byte)10, (byte)10, (byte)10, "10:10:10")]
        [DataRow((byte)20, (byte)5, (byte)2, "20:05:02")]
        [DataRow((byte)23, (byte)59, (byte)59, "23:59:59")]
        public void String_Constructor_And_Equal_Operator(byte h, byte m, byte s, string input)
        {
            Time t1 = new Time(h, m, s);
            Time t2 = new Time(input);
            Assert.AreEqual(true, t1 == t2);
        }

        [DataTestMethod]
        [DataRow((byte)10, (byte)10, (byte)10, (long)20, "10:10:30")]
        [DataRow((byte)10, (byte)10, (byte)10, (long)60, "10:11:10")]
        [DataRow((byte)10, (byte)10, (byte)10, (long)3600, "11:10:10")]
        [DataRow((byte)10, (byte)50, (byte)10, (long)3610, "11:50:20")]
        [DataRow((byte)10, (byte)50, (byte)10, (long)3660, "11:51:10")]
        public void Plus_TimePeriod(byte h, byte m, byte s, long seconds, string result)
        {
            Time time = new Time(h, m, s);
            TimePeriod timePeriod = new TimePeriod(seconds);

            Time time1 = time.PlusTimePeriod(timePeriod);
            Assert.AreEqual(result, time1.ToString());
        }

        [DataTestMethod]
        [DataRow((byte)10, (byte)10, (byte)10, (long)20, "10:10:30")]
        [DataRow((byte)10, (byte)10, (byte)10, (long)60, "10:11:10")]
        [DataRow((byte)10, (byte)10, (byte)10, (long)3600, "11:10:10")]
        [DataRow((byte)10, (byte)50, (byte)10, (long)3610, "11:50:20")]
        [DataRow((byte)10, (byte)50, (byte)10, (long)3660, "11:51:10")]
        public void Operator_Plus(byte h, byte m, byte s, long seconds, string result)
        {
            Time time = new Time(h, m, s);
            TimePeriod timePeriod = new TimePeriod(seconds);

            Time time1 = time + timePeriod;
            Assert.AreEqual(result, time1.ToString());
        }

    }

    [TestClass]
    public class TimePeriodTests
    {
        [DataTestMethod]
        [DataRow(3600, 3600)]
        [DataRow(0, 0)]
        [DataRow(44, 44)]
        [DataRow(12, 12)]
        public void TimePeriod_Constructor(long seconds, long expected)
        {
            TimePeriod timePeriod = new TimePeriod(seconds);
            Assert.AreEqual(timePeriod.Seconds, expected);
        }

        [DataTestMethod]
        [DataRow(-2)]
        [DataRow(long.MaxValue)]
        [DataRow(-100)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimePeriod_Constructor_WrongValues(long seconds)
        {
            seconds++;
            TimePeriod tp = new TimePeriod(seconds);
        }

        [DataTestMethod]
        [DataRow("0:0:0")]
        [DataRow("00:00:00")]
        [DataRow("01:01:01")]
        [DataRow("02:12:12")]
        [DataRow("23:59:59")]
        [DataRow("1:59:0")]
        [DataRow("534554:59:59")]
        public void TimePeriod_Constructor_StringCorrect(string input)
        {
            TimePeriod t = new TimePeriod(input);
        }

        [DataTestMethod]
        [DataRow("abcd")]
        [DataRow("hh:mm:ss")]
        [DataRow("")]
        [DataRow("00")]
        [DataRow("12:12::")]
        [DataRow("1:2,5,:")]
        [ExpectedException(typeof(FormatException))]
        public void TimePeriod_Constructor_String_Wrong(string input)
        {
            TimePeriod t = new TimePeriod(input);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)0, 3600)]
        [DataRow((byte)1, (byte)10, 4200)]
        [DataRow((byte)2, (byte)0, 2 * 3600)]
        [DataRow((byte)0, (byte)1, 60)]
        public void TimePeriod_Contructor_Hours_Minutes(byte h, byte m, long secondsExpected)
        {
            TimePeriod timePeriod = new TimePeriod(h, m);
            Assert.AreEqual(timePeriod.Seconds, secondsExpected);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)0, (byte)10, 3610)]
        [DataRow((byte)1, (byte)10, (byte)10, 4210)]
        [DataRow((byte)2, (byte)0, (byte)0, 2 * 3600)]
        [DataRow((byte)0, (byte)0, (byte)30, 30)]
        public void TimePeriod_Contructor_Hours_Minutes_Seconds(byte h, byte m, byte s, long secondsExpected)
        {
            TimePeriod timePeriod = new TimePeriod(h, m, s);
            Assert.AreEqual(timePeriod.Seconds, secondsExpected);
        }
    }
}
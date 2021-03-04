using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
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
    }
}
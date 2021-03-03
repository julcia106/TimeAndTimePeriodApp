//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTestProject
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//        }
//    }
//}


//using ClassLibrary;
//using System;
//using Xunit;

//namespace TimeTests
//{
//    public class CreateTimeTests
//    {
//        [Fact]
//        public void TimeConstructor()
//        {
//            //Test if the initial value of hour is positive and <= 24
//            Assert.Throws<ArgumentOutOfRangeException>(
//                () => new Time(25, 60, 10)
//            );

//            //Test if the initial value of minutes is positive and <= 60
//            Assert.Throws<ArgumentOutOfRangeException>(
//                () => new Time(24, 70, 10)
//            );

//            //Test if the initial value of seconds is positive and <= 60
//            Assert.Throws<ArgumentOutOfRangeException>(
//                () => new Time(24, 60, 100)
//            ); ;
//        }

//        [Fact]
//        public void TimeOperatorOverloadEquals()
//        {
//            Time p1 = new Time(12, 15, 20);
//            Time p1a = new Time(12, 15, 20);

//            Assert.True(p1 == p1a);
//        }

//        [Fact]
//        public void TimeOperatorOverloadNotEquals()
//        {
//            Time p1 = new Time(12, 15, 20);
//            Time p2 = new Time(10, 5, 2);

//            Assert.True(p1 != p2);
//        }

//        [Fact]
//        public void TimeOperatorOverloadMinus()
//        {
//            Time p1 = new Time(12, 15, 20);
//            Time p2 = new Time(10, 5, 2);

//            Time value = new Time(2, 10, 18);

//            Assert.True(value == (p1 - p2));
//        }

//        [Fact]
//        public void TimeOperatorOverloadIsGreaterOrEqual()
//        {
//            Time p1 = new Time(12, 15, 20);
//            Time p2 = new Time(10, 5, 2);

//            Assert.True(p1 >= p2);
//        }

//        [Fact]
//        public void TimeOperatorOverloadIsSmallerOrEqual()
//        {
//            Time p1 = new Time(10, 5, 2);
//            Time p2 = new Time(12, 15, 20);

//            Assert.True(p1 <= p2);
//        }

//        // cheking Time Plus(TimePeriod t1)
//        [Fact]
//        public void TimePlusTimePeriodMethod()
//        {
//            Time p1 = new Time(10, 5, 2);
//            TimePeriod p2 = new TimePeriod(2, 20, 9);

//            Time value = new Time(12, 25, 11);

//            Assert.True(value == p1.Plus(p2));
//        }

//        // checking Time operator +(Time t1, TimePeriod t2)
//        [Fact]
//        public void TimePlusTimePeriodOperatorOverload()
//        {
//            Time p1 = new Time(10, 5, 2);
//            TimePeriod p2 = new TimePeriod(2, 20, 9);

//            Time value = new Time(12, 25, 11);

//            Assert.True(value == (p1 + p2));
//        }

//        // Time Plus(Time t1, TimePeriod t2)
//        [Fact]
//        public void TimePlusMethodTimePlusTimePeriod()
//        {
//            Time p1 = new Time(10, 5, 2);
//            TimePeriod p2 = new TimePeriod(2, 20, 9);

//            Time value = new Time(12, 25, 11);

//            Assert.True(value == Time.Plus(p1, p2));
//        }

//        // TimePeriodTests -----------------------------------------------



//        // Equals(TimePeriod other)
//        [Fact]
//        public void TimePeriodEqualsMethod()
//        {
//            TimePeriod p1 = new TimePeriod(12, 15, 20);
//            TimePeriod p1a = new TimePeriod(12, 15, 20);

//            Assert.True(p1.Equals(p1a));
//        }

//        // checking bool operator ==(TimePeriod t1, TimePeriod t2)
//        [Fact]
//        public void TimePeriodOperatorOverloadEquals()
//        {
//            TimePeriod p1 = new TimePeriod(12, 15, 20);
//            TimePeriod p1a = new TimePeriod(12, 15, 20);

//            Assert.True(p1 == p1a);
//        }

//        // checking bool operator !=(TimePeriod t1, TimePeriod t2)
//        [Fact]
//        public void TimePeriodOperatorOverloadNotEquals()
//        {
//            TimePeriod p1 = new TimePeriod(12, 15, 20);
//            TimePeriod p2 = new TimePeriod(10, 5, 2);

//            Assert.True(p1 != p2);
//        }

//        // checking bool operator >=(TimePeriod left, TimePeriod right)
//        [Fact]
//        public void TimePeriodOperatorOverloadIsGreaterOrEqual()
//        {
//            TimePeriod p1 = new TimePeriod(12, 15, 20);
//            TimePeriod p2 = new TimePeriod(10, 5, 2);

//            Assert.True(p1 >= p2);
//        }

//        [Fact]
//        public void TimePeriodOperatorOverloadIsSmallerOrEqual()
//        {
//            TimePeriod p1 = new TimePeriod(10, 5, 2);
//            TimePeriod p2 = new TimePeriod(12, 15, 20);

//            Assert.True(p1 <= p2);
//        }

//        // cheking TimePeriod Plus(TimePeriod t1)
//        [Fact]
//        public void TimePeriodPlusTimePeriodMethod()
//        {
//            TimePeriod p1 = new TimePeriod(10, 5, 2);
//            TimePeriod p2 = new TimePeriod(2, 20, 9);

//            TimePeriod value = new TimePeriod(12, 25, 11);

//            Assert.True(value == p1.Plus(p2));
//        }

//        // checking TimePeriod Plus(TimePeriod t1, TimePeriod t2)
//        [Fact]
//        public void TimePeriodPlusTimePeriodSecondMethod()
//        {
//            TimePeriod p1 = new TimePeriod(10, 5, 2);
//            TimePeriod p2 = new TimePeriod(2, 20, 9);

//            TimePeriod value = new TimePeriod(12, 25, 11);

//            Assert.True(value == TimePeriod.Plus(p1, p2));
//        }

//        // checking TimePeriod operator +(TimePeriod t1, TimePeriod t2)
//        [Fact]
//        public void TimePeriodOperatorOverloadPlus()
//        {
//            TimePeriod p1 = new TimePeriod(10, 5, 2);
//            TimePeriod p2 = new TimePeriod(2, 20, 9);

//            TimePeriod value = new TimePeriod(12, 25, 11);

//            Assert.True(value == (p1 + p2));
//        }
//    }
//}

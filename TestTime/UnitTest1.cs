using TimeClass;

namespace TestTime
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InTime_Test_ToString()
        {
            Time t1 = new Time(86399);
            Time t2 = new Time(4, 40, 50);
            Time t3 = new Time(4, 40, 50);

            var str1 = t1.ToString();
            var str2 = t2.ToString();
            var str3 = t3.ToString();

            var str12 = (t1 + t2).ToString();
            var str13 = (t1 - t3).ToString();

            Assert.AreEqual("04:40:49", str12);
            Assert.AreEqual("19:19:09", str13);
        }

        [Test]
        public void InTime_MoreOperator()
        {
            Time t1 = new Time(86399);
            Time t2 = new Time(4, 40, 50);
            Time t3 = new Time(4, 40, 50);

            Assert.IsTrue(t1 > t2);
            Assert.IsTrue(t2 >= t3);
            Assert.IsFalse(t3 >= t1);
        }

        [Test]
        public void InTime_LessOperator()
        {
            Time t1 = new Time(86399);
            Time t2 = new Time(4, 40, 50);
            Time t3 = new Time(4, 40, 50);

            Assert.IsTrue(t2 < t1);
            Assert.IsTrue(t3 <= t1);
            Assert.IsFalse(t1 < t2);
        }

        [Test]
        public void InTime_Operators()
        {
            Time t1 = new Time(86399);
            Time t2 = new Time(4, 40, 50);
            Time t3 = new Time(4, 40, 50);

            var str12 = (t1 + t2).ToString();
            var str13 = (t1 - t3).ToString();

            Assert.AreEqual("04 | 40 | 49", str12);
            Assert.AreEqual("19 | 19 | 09", str13);

            //
        }
    }
}
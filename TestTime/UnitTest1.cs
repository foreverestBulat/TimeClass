using TimeClass;

namespace TestTime
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        // Method Name. State Under Test. Expected Behavior
        // Имя метода. Тестируемое состояние. Ожидаемое поведение

        [TestCase(1, 2, 3)]
        [TestCase(4, 5, 6)]
        [TestCase(5, 50, 37)]
        [TestCase(23, 59, 59)]
        public void InTime_ToString_True(int h, int m, int s)
        {
            Time t = new Time(h, m, s);

            var gettingResult = t.ToString();
            var expectedResult = String.Format("{0:00} | {1:00} | {2:00}", h, m, s);

            Assert.AreEqual(expectedResult, gettingResult);
        }

        [TestCase(0, 0, 86399, 4, 40, 50)]
        [TestCase(5, 50, 40, 4, 40, 10)]
        [TestCase(4, 10, 0, 4, 0, 45)]
        public void InTimeOperator_StrictlyMore_True(int h1, int m1, int s1, int h2, int m2, int s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.IsTrue(t1 > t2);
        }

        [TestCase(0, 0, 86399, 4, 40, 50)]
        [TestCase(5, 50, 40, 4, 40, 10)]
        [TestCase(4, 10, 0, 4, 0, 45)]
        public void InTimeOperator_NotStrictlyMore_True(int h1, int m1, int s1, int h2, int m2, int s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.IsTrue(t1 >= t2);
        }

        [TestCase(0, 0, 86399, 4, 40, 50)]
        [TestCase(5, 50, 40, 4, 40, 10)]
        [TestCase(4, 10, 0, 4, 0, 45)]
        public void InTimeOperator_StrictlyLess_True(int h1, int m1, int s1, int h2, int m2, int s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.IsTrue(t2 < t1);
        }


        [TestCase(0, 0, 86399, 4, 40, 50)]
        [TestCase(5, 50, 40, 4, 40, 10)]
        [TestCase(4, 10, 0, 4, 0, 45)]
        public void InTimeOperator_NotStrictlyLess_True(int h1, int m1, int s1, int h2, int m2, int s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.IsTrue(t2 <= t1);
        }


        [TestCase(0, 0, 86399, 4, 40, 50, "04 | 40 | 49")]
        [TestCase(5, 50, 40, 4, 40, 10, "10 | 30 | 50")]
        [TestCase(4, 10, 0, 4, 0, 45, "08 | 10 | 45")]
        public void InTimeOperator_summation_True(int h1, int m1, int s1, int h2, int m2, int s2, string expectedResult)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            var gettingResult = (t1 + t2).ToString();

            Assert.AreEqual(expectedResult, gettingResult);
        }

        [TestCase(0, 0, 86399, 4, 40, 50, "19 | 19 | 09")]
        [TestCase(5, 50, 40, 4, 40, 10, "01 | 10 | 30")]
        [TestCase(4, 10, 0, 4, 0, 45, "00 | 09 | 15")]
        public void InTimeOperator_Subtraction_True(int h1, int m1, int s1, int h2, int m2, int s2, string expectedResult)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            var gettingResult = (t1 - t2).ToString();

            Assert.AreEqual(expectedResult, gettingResult);
        }

        [TestCase(2, 4, 40, 50, "09 | 21 | 40")]
        [TestCase(3, 4, 40, 50, "14 | 02 | 30")]
        [TestCase(5, 6, 66, 66, "11 | 35 | 30")]
        public void InTimeOperators_Mult_True(int a, int h, int m, int s, string expectedResult)
        {
            Time t1 = new Time(h, m, s);

            var gettingResult = (t1 * a).ToString();

            Assert.AreEqual(expectedResult, gettingResult);
        }

        private bool GetException(Time t1, Time t2)
        {
            var t3 = t1 - t2;
            return true;
        }

        [TestCase(0, 0, 86399, 4, 40, 50)]
        [TestCase(1, 2, 3, 1, 2, 2)]
        [TestCase(123, 123, 123, 123, 123, 122)]
        public void InTimeOperator_Subtraction_Exception(int h1, int m1, int s1, int h2, int m2, int s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.That(() => GetException(t2, t1), Throws.TypeOf<ArgumentException>());
        }
    }
}

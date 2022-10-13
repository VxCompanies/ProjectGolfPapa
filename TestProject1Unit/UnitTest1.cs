//namespace TestProject1Unit
//{
//    public class Tests
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public void Test1()
//        {
//            Assert.Pass();
//        }
//    }
//}

using NUnit.Framework;

namespace TestProject1Unit
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
   
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void InputIs1_ReturnFalse()
        {
            //Assert.Pass();
            var result = 1;
            Assert.NotZero(result, $"{result} No igual a 0");
        }

        [Test]
        public void InputIs0_ReturnFalse()
        {
            //Assert.Pass();
            var result = 0;
            Assert.NotZero(result, $"{result} No igual a 0");
        }
    }
}
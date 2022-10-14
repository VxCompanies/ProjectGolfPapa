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
using ProjectGolfPapa.Models;
using System.Security.Cryptography.X509Certificates;

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
        public void ValoresVacios()
        {
            var Names = new List<string>() { "Firaluais 1", "Firaluais 2", "Firaluais 1", " " };
            var ListAnimal = new List<String>() { "Pastor Aleman", "Pitbull", "Chihuahua", " " };
            var GenderName = new List<string>() { "Masculino", "Femenino", " "};
            var RaceName = new List<string>() { "Raza 1", "Raza 2", "Raza 3", " " };

            var pet = new Pet()
            {
                Name = Names[new Random().Next(0, 4)],
                Animal = ListAnimal[new Random().Next(0,4)],
                Gender = GenderName[new Random().Next(0,3)],
                Race =  RaceName[new Random().Next(0,4)],
            };

            Assert.AreNotEqual( " ", pet.Name);
            Assert.AreNotEqual(" ", pet.Animal);
            Assert.AreNotEqual(" ", pet.Gender);
            Assert.AreNotEqual(" ", pet.Race);


        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingPocRedis.Domain;
using TrainingPocRedis.Repository;

namespace TrainingPocRedis.Test
{
    [TestClass]
    public class TrainingPocRedisRepositoryTest
    {
        [TestMethod]
        public void TestAdd_Success()
        {
            //Arrange
            RedisRepository<Client> testRepository = new Repository.RedisRepository<Client>("localhost");

            Client clientTest = new Client()
            {
                Id = 25,
                Nome = "NomeTeste",
                NumeroCompra = "2254545TT546A"
            };
            string key = typeof(Client).Name + ":" + clientTest.Id;

            bool expectedValue = true;

            //Act
            bool resultOperation = testRepository.Add(key, clientTest);

            //Assert
            Assert.AreEqual(expectedValue, resultOperation);

        }

        [TestMethod]
        public void TestAddWithTimeout_Success()
        {
            //Arrange
            RedisRepository<Client> testRepository = new Repository.RedisRepository<Client>("localhost");

            Client clientTest = new Client()
            {
                Id = 38,
                Nome = "NomeComTimeoutTeste",
                NumeroCompra = "22AAAb5TT546A"
            };
            string key = typeof(Client).Name + ":" + clientTest.Id;

            bool expectedValue = true;

            //Act
            bool resultOperation = testRepository.AddWithExpiration(key, 180, clientTest);

            //Assert
            Assert.AreEqual(expectedValue, resultOperation);

        }

        [TestMethod]
        public void TestListById_Success()
        {
            //Arrange
            int expected = 38;

            RedisRepository<Client> testRepository = new Repository.RedisRepository<Client>("localhost");
            string key = typeof(Client).Name + ":" + expected;
            //Act

            Client resultOperation = (Client)testRepository.ListById(key);

            //Assert
            Assert.AreEqual(expected, resultOperation.Id);

        }

        [TestMethod]
        public void TestDelete_Success()
        {
            //Arrange
            bool expected = true;

            RedisRepository<Client> testRepository = new Repository.RedisRepository<Client>("localhost");
            string key = typeof(Client).Name + ":" + 38;
            //Act

            //bool actual = testRepository.DeleteAsync(key);
            var actual = testRepository.Delete(key);

            //Assert
            Assert.AreEqual(expected, actual);

        }

    }
}

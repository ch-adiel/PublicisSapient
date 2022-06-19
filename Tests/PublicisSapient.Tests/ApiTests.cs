using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PublicisSapient.Controllers;
using PublicisSapient.Models;
using PublicisSapient.Models.ViewModels;
using PublicisSapient.Profiles;
using PublicisSapient.Repositories;
using PublicisSapient.Repositories.Context;
using PublicisSapient.Repositories.Interfaces;
using System.Linq;
using System.Net.Http;

namespace PublicisSapient.Tests
{
    [TestFixture]
    public class ApiTests
    {
        private CreditCardsController _creditCardsController;
        private PublicisSapientContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<PublicisSapientContext>()
                .UseInMemoryDatabase(databaseName: "PublicisSapient_Tests")
                .Options;
            _dbContext = new PublicisSapientContext(options);
            IRepository<CreditCard> repository = new Repository<CreditCard>(_dbContext);

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());

            _creditCardsController = new CreditCardsController(repository, mapperConfig.CreateMapper());
        }

        [Test]
        public void Saving_CreditCard()
        {
            var model = new CreditCardRequestModel()
            {
                CardName = "Test",
                CardLimit = 1000,
                CardNumber = "5105105105105100"
            };

            var response = _creditCardsController.Save(model);

            Assert.AreEqual(true, response.Status);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("Success", response.Message);
            Assert.NotNull(response.Data);
            Assert.Greater(response.Data.Id, 0);
            Assert.AreEqual(0, response.Data.Balance);
            Assert.AreEqual(1000, response.Data.CardLimit);
        }

        [Test]
        public void WhenCardNumberExists_ThenAlreadyExistsError()
        {
            var model = new CreditCardRequestModel()
            {
                CardName = "Test1",
                CardLimit = 2000,
                CardNumber = "5105105105105100"
            };

            _creditCardsController.Save(model);

            model = new CreditCardRequestModel()
            {
                CardName = "Test2",
                CardLimit = 1000,
                CardNumber = "5105105105105100"
            };

            var response = _creditCardsController.Save(model);

            Assert.AreEqual(false, response.Status);
            Assert.AreEqual(204, response.StatusCode);
            Assert.AreEqual("Card already exists", response.Message);
            Assert.NotNull(response.Data);
            Assert.Greater(response.Data.Id, 0);
        }

        [Test]
        public void Getting_CreditCard()
        {
            var model = new CreditCardRequestModel()
            {
                CardName = "Test",
                CardLimit = 1000,
                CardNumber = "5105105105105100"
            };

            var response1 = _creditCardsController.Save(model);

            var response = _creditCardsController.Get(response1.Data.Id);

            Assert.AreEqual(true, response.Status);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("Success", response.Message);
            Assert.NotNull(response.Data);
            Assert.AreEqual(1, response.Data.Count);
            Assert.Greater(response.Data.First().Id, 0);
            Assert.AreEqual(0, response.Data.First().Balance);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}

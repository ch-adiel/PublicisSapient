using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PublicisSapient.Models;
using PublicisSapient.Repositories;
using PublicisSapient.Repositories.Context;
using PublicisSapient.Repositories.Interfaces;

namespace PublicisSapient.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private IRepository<CreditCard> _repository;
        private PublicisSapientContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<PublicisSapientContext>()
                .UseInMemoryDatabase(databaseName: "PublicisSapient_Tests")
                .Options;
            _dbContext = new PublicisSapientContext(options);
            _repository = new Repository<CreditCard>(_dbContext);
        }

        [Test]
        public void WhenSavingCreditCard_ThenIdAutoIncrement_BalanceisZero()
        {
            var creditCard = new CreditCard()
            {
                CardName = "Test",
                CardNumber = "1234567890123456",
                CardLimit = 1000
            };

            _repository.Insert(creditCard);

            Assert.Greater(creditCard.Id, 0);
            Assert.AreEqual(0, creditCard.Balance);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}

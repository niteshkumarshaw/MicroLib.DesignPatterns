using MicroLib.DesignPatterns.RepositoryPattern;
using MicroLib.DesignPatternsTests.MockData;
using MicroLib.DesignPatternsTests.MockData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MicroLib.DesignPatternsTests.RepositoryPattern
{
    [TestClass]
    public class Repository_Functanality
    {
        private EntityFrameworkInmemoryDbContext ctx;
        private IRepository<MocProfileInfo, int> repo;

        [TestInitialize]
        public void Settup()
        {
            var options = new DbContextOptionsBuilder<EntityFrameworkInmemoryDbContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            ctx = new EntityFrameworkInmemoryDbContext(options);

            repo = new Repository<MocProfileInfo, int>(ctx);
        }

        [TestMethod]
        public void Test_AddFunctanality()
        {
            repo.Add(new MocProfileInfo() { Id = 1, FullName = "Tim Waang", Email = "tim.waang@domain.com" });
            repo.Add(new MocProfileInfo() { Id = 2, FullName = "Jhon Doe", Email = "doe.jhon@domain.com" });
            ctx.SaveChanges();
            var list = repo.GetAll();

            Assert.AreEqual(2, list.ToList().Count);
        }
    }
}
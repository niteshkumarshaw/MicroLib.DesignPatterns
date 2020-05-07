using MicroLib.DesignPatterns.RepositoryPattern;
using MicroLib.DesignPatternsTests.MockData;
using MicroLib.DesignPatternsTests.MockData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        [TestCleanup]
        public void Cleanup()
        {
            ctx = null;
            repo = null;
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

        [TestMethod]
        public async Task Test_AddFunctanalityAsync()
        {
            await repo.AddAsync(new MocProfileInfo() { Id = 1, FullName = "Tim Waang", Email = "tim.waang@domain.com" });
            await repo.AddAsync(new MocProfileInfo() { Id = 2, FullName = "Jhon Doe", Email = "doe.jhon@domain.com" });
            await ctx.SaveChangesAsync();
            var list = await repo.GetAllAsync();

            Assert.AreEqual(2, list.ToList().Count);
        }

        [TestMethod]
        public void Test_DelAndFindFunctanality()
        {
            repo.AddAsync(new MocProfileInfo() { Id = 1, FullName = "Tim Waang", Email = "tim.waang@domain.com" }).Wait();
            repo.AddAsync(new MocProfileInfo() { Id = 2, FullName = "Jhon Doe", Email = "doe.jhon@domain.com" }).Wait();
            ctx.SaveChangesAsync().Wait();

            var dels = repo.Find(e => e.FullName == "Jhon Doe");
            repo.Remove(dels);

            ctx.SaveChangesAsync().Wait();
            var list = repo.GetAllAsync().Result;

            Assert.AreEqual(1, list.ToList().Count);
        }
    }
}
using MicroLib.DesignPatternsTests.MockData.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroLib.DesignPatternsTests.MockData
{
    public class EntityFrameworkInmemoryDbContext : DbContext
    {
        public virtual DbSet<MocProfileInfo> ProfileInfos { get; set; }

        public EntityFrameworkInmemoryDbContext(DbContextOptions<EntityFrameworkInmemoryDbContext> options) : base(options)
        {
        }
    }
}
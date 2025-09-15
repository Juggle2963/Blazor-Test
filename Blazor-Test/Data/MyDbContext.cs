using Blazor_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Test.Data
{
    public class MyDbContext : DbContext
{
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; } = default!;
}
}

using Microsoft.EntityFrameworkCore;
using MiniProject.Models;
namespace MiniProject.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }
        public DbSet<User> UserTabel { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}

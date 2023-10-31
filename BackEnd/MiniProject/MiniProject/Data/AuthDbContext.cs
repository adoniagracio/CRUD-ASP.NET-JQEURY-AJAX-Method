using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MiniProject.Data
{
    public class AuthDbContext : IdentityDbContext<AppliactionUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 
        }
    }
}

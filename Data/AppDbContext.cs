using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebFamilyHome.Models;
using Group = WebFamilyHome.Models.Group; // alias para evitar conflito

namespace WebFamilyHome.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
    }
}

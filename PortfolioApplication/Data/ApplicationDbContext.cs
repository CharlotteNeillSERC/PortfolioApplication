using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioApplication.Models;

namespace PortfolioApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PortfolioApplication.Models.Portfolio> Portfolio { get; set; }
        public DbSet<PortfolioApplication.Models.ContactInfo> ContactInfo { get; set; }
    }
}
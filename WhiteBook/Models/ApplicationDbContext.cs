using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteBook.Models;

namespace WhiteBook.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<MigrationType> MigrationTypes { get; set; }

        public DbSet<GermanyRegion> GermanyRegions { get; set; }
        public DbSet<GermanyCity> GermanyCities { get; set; }

        public DbSet<Religion> Religions { get; set; }
        public DbSet<Confession> Confessions { get; set; }

        public DbSet<TerroristAttackType> TerroristAttackTypes { get; set; }

        public DbSet<RiskyLevel> RiskyLevels { get; set; }
        public DbSet<PoliticalPartiesMovement> PoliticalPartiesMovements { get; set; }
        public DbSet<RadicalOrganization> RadicalOrganizations { get; set; }

        public DbSet<TerroristAttack> TerroristAttacks { get; set; }

        public DbSet<CyberThreatType> CyberThreatTypes { get; set; }
        public DbSet<CyberThreat> CyberThreats { get; set; }
        public DbSet<MigrationFlow> MigrationFlow { get; set; }

        public DbSet<Danger> Dangers { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<DangerYear> DangerYears { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<DangerYear>().HasKey(t => new { t.DangerId, t.YearId });
            builder.Entity<DangerYear>()
                .HasOne(d => d.Danger)
                .WithMany(d => d.DangerYears)
                .HasForeignKey(d => d.DangerId);

            builder.Entity<DangerYear>()
                .HasOne(s => s.Year)
                .WithMany(s => s.DangerYears)
                .HasForeignKey(s => s.YearId);

        }
    }
}

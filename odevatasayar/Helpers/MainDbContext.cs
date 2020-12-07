using Microsoft.EntityFrameworkCore;
using odevatasayar.Models;

namespace odevatasayar.Helpers
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {}
        public DbSet<odevatasayar.Models.Kullanici> Kullanici { get; set; }
        public DbSet<odevatasayar.Models.Sirket> Sirket { get; set; }
        public DbSet<odevatasayar.Models.SirketLider> SirketLider { get; set; }
        public DbSet<odevatasayar.Models.Organizasyon> Organizasyon { get; set; }
        public DbSet<odevatasayar.Models.OrganizasyonLider> OrganizasyonLider { get; set; }
        public DbSet<odevatasayar.Models.Bolge> Bolge { get; set; }
        public DbSet<odevatasayar.Models.BolgeLider> BolgeLider { get; set; }
        public DbSet<odevatasayar.Models.Ofis> Ofis { get; set; }
        public DbSet<odevatasayar.Models.OfisLider> OfisLider { get; set; }
        public DbSet<odevatasayar.Models.Takim> Takim { get; set; }
        public DbSet<odevatasayar.Models.TakimLider> TakimLider { get; set; }
        public DbSet<odevatasayar.Models.Uye> Uye { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PutniNalogDataContext.PN.Database
{
    public class PNDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=PN;Username=postgres; Password=5526");
        }

        public PNDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<MjestoPutovanja>? MjestoPutovanja { get; set; }
        public DbSet<PutniNalog>? PutniNalog { get; set; }
        public DbSet<PutniTroskovi>? PutniTroskovi { get; set; }
        public DbSet<RadnoMjesto>? RadnoMjesto { get; set; }
        public DbSet<Vozilo>? Vozilo { get; set; }
        public DbSet<VrstaTroska>? VrstaTroska { get; set; }
        public DbSet<Zaposlenik>? Zaposlenik { get; set; }

    }
}

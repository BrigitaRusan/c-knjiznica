using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using knjiznica.Models;

namespace knjiznica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

    }
    public class KnjiznicaContext : DbContext
    {
        public KnjiznicaContext(DbContextOptions<KnjiznicaContext> options) : base(options) { }

        public DbSet<KnjiznicarModel> Knjiznicari { get; set; }
        public DbSet<KnjiznicaModel> Knjiznice { get; set; }
        public DbSet<KnjigaModel> Knjige { get; set; }
        public DbSet<KorisnikModel> Korisnici { get; set; }
        public DbSet<KnjiznicaKnjigaModel> KnjiznicaKnjige { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<KnjiznicarModel>().ToTable("Knjiznicar");
            modelBuilder.Entity<KnjiznicaModel>().ToTable("Knjiznica");
            modelBuilder.Entity<KnjigaModel>().ToTable("Knjige");
            modelBuilder.Entity<KorisnikModel>().ToTable("Korisnici");
            modelBuilder.Entity<KnjiznicaKnjigaModel>().ToTable("Knjiz_knjige");

            modelBuilder.Entity<KnjiznicarModel>()    // knjiznica - knjiznicar
                .HasOne(k => k.Knjiznica)
                .WithMany(kj => kj.Knjiznicari)
                .HasForeignKey(k => k.Id_knjiznice);

            modelBuilder.Entity<KnjiznicaKnjigaModel>()
                .HasKey(k => new { k.Id_knjige, k.Id_knjiznice });  // Kombinirani ključ za pomoćnu tablicu

            modelBuilder.Entity<KnjiznicaKnjigaModel>()  
                .HasOne(k => k.Knjiga)
                .WithMany(k => k.KnjizniceKnjige)
                .HasForeignKey(k => k.Id_knjige);

            modelBuilder.Entity<KnjiznicaKnjigaModel>()
                .HasOne(k => k.Knjiznica)
                .WithMany(k => k.KnjizniceKnjige)
                .HasForeignKey(k => k.Id_knjiznice);
        }


    }
}
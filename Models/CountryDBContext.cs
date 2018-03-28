using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab3_MVC_.Models
{
    public partial class CountryDBContext : DbContext
    {
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Settlements> Settlements { get; set; }

        public CountryDBContext(DbContextOptions<CountryDBContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Districts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idregion).HasColumnName("IDRegion");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Capital)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Settlements>(entity =>
            {
                entity.HasKey(e => e.SettlementId);

                entity.Property(e => e.SettlementId).HasColumnName("ID");

                entity.Property(e => e.Iddistrict).HasColumnName("IDDistrict");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}

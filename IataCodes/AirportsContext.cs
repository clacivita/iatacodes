using System;
using Microsoft.EntityFrameworkCore;

namespace IataCodes
{
    public partial class AirportsContext : DbContext
    {
        private const string ConnectionString = "Server=airports.culwsrqbkqhh.us-east-1.rds.amazonaws.com;Database=Airports;UID=clacivita;PWD=ZaphodB1!";

        public AirportsContext()
        {
        }

        public AirportsContext(DbContextOptions<AirportsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airports> Airports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Airports>(entity =>
            {
                entity.HasIndex(e => e.Iatacode)
                    .HasName("UQ_Airports_IATACode")
                    .IsUnique();

                entity.HasIndex(e => e.Icaocode)
                    .HasName("UQ_Airports_ICAOCode")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Dst)
                    .IsRequired()
                    .HasColumnName("DST")
                    .HasMaxLength(6);

                entity.Property(e => e.FullCountry)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Iatacode)
                    .IsRequired()
                    .HasColumnName("IATACode")
                    .HasMaxLength(6);

                entity.Property(e => e.Icaocode)
                    .IsRequired()
                    .HasColumnName("ICAOCode")
                    .HasMaxLength(6);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.TimezoneName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(32);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebServiceMemory.Models
{
    public partial class MemoryContext : DbContext
    {
        public MemoryContext()
        {
        }

        public MemoryContext(DbContextOptions<MemoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CombinationFound> CombinationFounds { get; set; }
        public virtual DbSet<Coordinate> Coordinates { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<PlayersScore> PlayersScores { get; set; }
        public virtual DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Memory;user Id=memoryapi;Password=memoryapi123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CombinationFound>(entity =>
            {
                entity.ToTable("CombinationFound");

                entity.Property(e => e.Name).HasMaxLength(60);
            });

            modelBuilder.Entity<Coordinate>(entity =>
            {
                entity.ToTable("Coordinate");

                entity.Property(e => e.ColumnNumbers).HasColumnName("columnNumbers");

                entity.Property(e => e.RowNumbers).HasColumnName("rowNumbers");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image1).HasColumnName("Image");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsFixedLength(true);

                entity.Property(e => e.Theme)
                    .HasMaxLength(60)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PlayersScore>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("PlayersScore");

                entity.Property(e => e.Pk).HasColumnName("PK");

                entity.Property(e => e.PlayerName).HasMaxLength(60);
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("Score");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsFixedLength(true);

                entity.Property(e => e.Score1).HasColumnName("Score");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

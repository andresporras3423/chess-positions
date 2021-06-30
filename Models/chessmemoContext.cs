using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class chessmemoContext : DbContext
    {
        public chessmemoContext()
        {
        }

        public chessmemoContext(DbContextOptions<chessmemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=project-teleperformance.database.windows.net;Initial Catalog=chessmemo;User ID=oscar;Password=Jenny-1997");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("player");

                entity.HasIndex(e => e.Email, "UQ__player__AB6E61646E699D5B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.Salt).HasColumnName("salt");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AvailableMoves).HasColumnName("available_moves");

                entity.Property(e => e.BlackLongCastling).HasColumnName("black_long_castling");

                entity.Property(e => e.BlackShortCastling).HasColumnName("black_short_castling");

                entity.Property(e => e.Board)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("board");

                entity.Property(e => e.LastMove)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_move");

                entity.Property(e => e.TotalPieces).HasColumnName("total_pieces");

                entity.Property(e => e.WhiteLongCastling).HasColumnName("white_long_castling");

                entity.Property(e => e.WhiteShortCastling).HasColumnName("white_short_castling");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

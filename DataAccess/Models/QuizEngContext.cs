using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Models
{
    public partial class QuizEngContext : DbContext
    {
        public QuizEngContext()
        {
        }

        public QuizEngContext(DbContextOptions<QuizEngContext> options)
            : base(options)
        {
        }

        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string ConnectionStr = config.GetConnectionString("DB");

                optionsBuilder.UseSqlServer(ConnectionStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.TakenAt).HasColumnType("datetime");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__History__QuizId__60A75C0F");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__History__Student__5FB337D6");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.CorrectAnswer).HasMaxLength(255);

                entity.Property(e => e.MaxScore).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__Questions__QuizI__5812160E");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.TakenAt).HasColumnType("datetime");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__Results__QuizId__5BE2A6F2");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Results__Student__5AEE82B9");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

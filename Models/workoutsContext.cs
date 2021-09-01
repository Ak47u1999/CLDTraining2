using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CLDTraining2.Models
{
    public partial class workoutsContext : DbContext
    {
        public workoutsContext()
        {
        }

        public workoutsContext(DbContextOptions<workoutsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WorkoutList> WorkoutList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=workouts;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutList>(entity =>
            {
                entity.HasKey(e => e.MuscleGroup)
                    .HasName("PK__workoutL__C9BBFB439596F69E");

                entity.ToTable("workoutList");

                entity.Property(e => e.MuscleGroup)
                    .HasColumnName("muscleGroup")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ExerciseName)
                    .HasColumnName("exerciseName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RepsNum).HasColumnName("repsNum");

                entity.Property(e => e.SetsNum).HasColumnName("setsNum");

                entity.Property(e => e.Split)
                    .HasColumnName("split")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

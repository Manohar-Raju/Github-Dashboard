using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyFirstAPI.Models
{
    public partial class studentsContext : DbContext
    {
       

        public studentsContext(DbContextOptions<studentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> StudentsModel { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Place)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Age);
                entity.Property(e => e.Contact);
            });


            modelBuilder.Entity<Courses>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Instructor).HasMaxLength(20);
                entity.Property(e => e.Duration).HasMaxLength(20);
            });

                OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

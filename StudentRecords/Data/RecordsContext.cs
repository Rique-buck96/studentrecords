using Microsoft.EntityFrameworkCore;
using StudentRecords.Models;

namespace StudentRecords.Data
{
    public class RecordsContext : DbContext
    {
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Units> Units { get; set; }

        public RecordsContext(DbContextOptions<RecordsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Units>(entity =>
            {
                entity.ToTable("Units");
                entity.HasKey(e => e.UnitCode);
                entity.Property(e => e.UnitCode).IsRequired();
                entity.Property(e => e.UnitCoordinator).IsRequired();
                entity.Property(e => e.UnitOutline).IsRequired();
                entity.Property(e => e.UnitTitle).IsRequired();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.IsAdmin).IsRequired();
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.ToTable("Results");
                entity.HasKey(e => e.StudentId);
                entity.HasMany(d => d.Unit).WithOne(p => p.Results).HasForeignKey(d => d.UnitCode);
                entity.Property(e => e.UnitCode).IsRequired();
                entity.Property(e => e.StudentId).IsRequired();
                entity.Property(e => e.Ass1Score).IsRequired();
                entity.Property(e => e.Ass2Score).IsRequired();
                entity.Property(e => e.ExamScore).IsRequired();
                entity.Property(e => e.Semester).IsRequired();
                entity.Property(e => e.Year).IsRequired();
            });
        }
    }
}

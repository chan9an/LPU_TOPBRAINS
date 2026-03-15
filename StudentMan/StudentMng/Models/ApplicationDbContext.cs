using Microsoft.EntityFrameworkCore;

namespace StudentMngSystem14_03_26.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

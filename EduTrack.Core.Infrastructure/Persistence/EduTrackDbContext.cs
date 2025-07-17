using Microsoft.EntityFrameworkCore;
using EduTrack.Core.Domain.Entities; // Domain project ke entities ke liye reference

namespace EduTrack.Core.Infrastructure.Persistence
{
    public class EduTrackDbContext : DbContext
    {
        public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options) : base(options)
        {
        }


        // Yahan apni entities ke DbSet add karo
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admin { get; set; }
        public  DbSet<Department> Departments { get; set; }    
    

        // Agar aur entities hain to yahan add kar sakte ho\

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configuration can go here in the future
            modelBuilder.Entity<Student>().ToTable("Student");          
            modelBuilder.Entity<Teacher>().ToTable("Teachers");         
            modelBuilder.Entity<Course>().ToTable("Courses");           
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");    
            modelBuilder.Entity<Attendance>().ToTable("Attendances");   
            modelBuilder.Entity<Marks>().ToTable("Marks");              
            modelBuilder.Entity<Timetable>().ToTable("Timetable");
            modelBuilder.Entity<Department>().ToTable("Department");

            modelBuilder.Entity<Marks>()
    .Property(m => m.Score)
    .HasPrecision(10, 2); // 10 total digits, 2 after decimal

        }
    }
}

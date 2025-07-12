using Microsoft.EntityFrameworkCore;
using EduTrack.Domain.Entities; // Domain project ke entities ke liye reference

namespace EduTrack.Infrastructure.Persistence
{
    public class EduTrackDbContext : DbContext
    {
        public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options) : base(options)
        {
        }
    

        // Yahan apni entities ke DbSet add karo
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        // Agar aur entities hain to yahan add kar sakte ho
    }
}

using BallroomWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BallroomWebApp.Data
{
    public class MvcDanceContext : DbContext
    {
        public MvcDanceContext(DbContextOptions<MvcDanceContext> options) : base(options)
        {
            
        }
        
        public DbSet<Dance> Dance { get; set; }
        public DbSet<DanceMove> DanceMove { get; set; }
        public DbSet<DanceVideo> DanceVideo { get; set; }
        public DbSet<Syllabus> Syllabus { get; set; }
    }
}
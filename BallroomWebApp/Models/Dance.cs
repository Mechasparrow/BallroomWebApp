using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace BallroomWebApp.Models
{
    public class Dance
    {
        public int DanceId { get; set; }
        
        public string Name { get; set; }
        public string Speed { get; set; } // Smooth or Rhythm
    }
}
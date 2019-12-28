namespace BallroomWebApp.Models
{
    public class Syllabus
    {
        public int SyllabusId { get; set; }
        
        public int Level { get; set; }

        public int DanceId { get; set; }
        public Dance Dance { get; set; }
    }
}    
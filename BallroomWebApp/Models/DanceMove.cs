namespace BallroomWebApp.Models
{
    public class DanceMove
    {
        public int DanceMoveId { get; set; }
        
        public int DanceVideoId { get; set; }
        public DanceVideo Video { get; set; }
        
        public int SyllabusId { get; set; }
        public Syllabus Syllabus { get; set; }
    }
}
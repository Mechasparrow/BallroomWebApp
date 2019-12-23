namespace BallroomWebApp.Models
{
    public class DanceMove
    {
        public int Id { get; set; }
        public DanceVideo Video { get; set; }
        public Syllabus Syllabus { get; set; }
    }
}
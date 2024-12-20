
namespace ArtStudioManager.Components.Models
{
    public class Attendance
    {
        public Artist Artist { get; set; }
        public bool Attended { get; set; }

        public Attendance(Artist artist, bool attended)
        {
            Artist = artist;
            Attended = attended;
        }
    }
}

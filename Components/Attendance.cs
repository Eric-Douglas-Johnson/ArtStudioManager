
namespace ArtStudioManager.Components
{
    public class Attendance
    {
        public ICollection<AttendanceMark> AttendanceRecord { get; set; }

        public Attendance()
        {
            AttendanceRecord = new List<AttendanceMark>();
        }

        public void AddAttendees(ICollection<Artist> artists)
        {
            foreach (var artist in artists)
            {
                AddAttendanceMark(artist, false);
            }
        }

        public void AddAttendanceMark(Artist artist, bool mark)
        {
            if (artist == null) { throw new ArgumentException("Artist is null."); }
            if (artist.Name == null) { throw new ArgumentException("Artist must have a name."); }

            AttendanceRecord.Add(new AttendanceMark { Artist = artist, Attended = mark });
        }

        public void EditAttendanceMark(string artistName, bool mark)
        {
            foreach (var attendanceMark in AttendanceRecord)
            {
                if (attendanceMark.Artist!.Name! == artistName)
                {
                    attendanceMark.Attended = mark;
                }
            }
        }
    }

    public class AttendanceMark
    {
        public Artist? Artist { get; set; }
        public bool Attended { get; set; }
    }
}


namespace ArtStudioManager.Components.Models
{
    public class Attendance
    {
        public IList<AttendanceMark> AttendanceRecord { get; set; }

        public Attendance()
        {
            AttendanceRecord = new List<AttendanceMark>();
        }

        public void AddAttendee(Artist artist)
        {
            AddAttendanceMark(artist, false);
        }

        public void AddAttendees(ICollection<Artist> artists)
        {
            foreach (var artist in artists)
            {
                AddAttendanceMark(artist, false);
            }
        }

        private void AddAttendanceMark(Artist artist, bool mark)
        {
            if (artist == null) { throw new ArgumentException("Artist is null."); }
            if (artist.Name == null) { throw new ArgumentException("Artist must have a name."); }

            AttendanceRecord.Add(new AttendanceMark { Artist = artist, Attended = mark });
        }

        public void RemoveAttendee(Guid artistId)
        {
            for (int i = 0; i < AttendanceRecord.Count; i++)
            {
                if (AttendanceRecord[i].Artist!.Id == artistId)
                {
                    AttendanceRecord.RemoveAt(i);
                }
            }
        }

        public bool ArtistIsAttending(Guid artistId)
        {
            return AttendanceRecord.Any(x => x.Artist!.Id == artistId);
        }
    }
}


namespace ArtStudioManager.Components.Models
{
    public class AttendanceRecord
    {
        public IList<Attendance> Attendances { get; set; }

        public AttendanceRecord()
        {
            Attendances = new List<Attendance>();
        }

        public void AddAttendee(Artist artist)
        {
            AddAttendance(artist, false);
        }

        public void AddAttendees(ICollection<Artist> artists)
        {
            foreach (var artist in artists)
            {
                AddAttendance(artist, false);
            }
        }

        public void AddAttendance(Artist artist, bool attended)
        {
            if (artist == null) { throw new ArgumentException("Artist is null."); }
            if (artist.Name == null) { throw new ArgumentException("Artist must have a name."); }

            Attendances.Add(new Attendance(artist, attended));
        }

        public void RemoveAttendee(Guid artistId)
        {
            for (int i = 0; i < Attendances.Count; i++)
            {
                if (Attendances[i].Artist!.Id == artistId)
                {
                    Attendances.RemoveAt(i);
                }
            }
        }

        public bool ArtistIsAttending(Guid artistId)
        {
            return Attendances.Any(x => x.Artist!.Id == artistId);
        }
    }
}

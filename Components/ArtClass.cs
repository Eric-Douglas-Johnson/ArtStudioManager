
namespace ArtStudioManager.Components
{
    public class ArtClass
    {
        public Guid Id { get; private set; }
        public ClassType Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Cost { get; set; }
        public Discount? MemberDiscount { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<Artist>? Artists { get; set; }
        public ICollection<Material>? Materials { get; set; }
        public Attendance? Attendance { get; set; }
       
        public ArtClass()
        {
            Id = Guid.NewGuid();
        }

        public ArtClass(Guid id, IDataLoader<ArtClass> dataLoader)
        {
            Id = id;
            dataLoader.Load(this);
        }

        /// <summary>
        /// Gets the total dollars brought in by the class.
        /// </summary>
        /// <returns>A raw dollar amount, i.e. not rounded.</returns>
        public decimal? GetTotalDollars()
        {
            decimal? totalDollars = 0;

            if (Artists != null && Artists.Count > 0)
            {
                var memberCount = Artists.Where(x => x.GetArtistType() == Artist.ArtistType.Member).Count();
                var nonMemberCount = Artists.Count - memberCount;
                decimal totalCostForAllMembers;     

                if (MemberDiscount is Discount discount)
                {
                    decimal costPerMember = Cost - MemberDiscount.GetAmount();
                    totalCostForAllMembers = costPerMember * memberCount;
                }
                else
                {
                    totalCostForAllMembers = Cost * memberCount;
                }

                decimal totalCostForAllNonMembers = Cost * nonMemberCount;

                totalDollars = totalCostForAllMembers + totalCostForAllNonMembers;
            }

            return totalDollars;
        }

        public Instructor GetPrimaryInstructor()
        {
            if (Instructors != null &&  Instructors.Count > 0)
            {
                foreach (var instructor in Instructors)
                {
                    if (instructor.IsPrimary)
                    {
                        return instructor;
                    }
                }
            }

            throw new InvalidOperationException("There is no primary instructor.");
        }

        public void SaveAttendance()
        {
            if (Attendance == null) { throw new InvalidOperationException("Attendance does not exist."); }

            foreach (var mark in Attendance.AttendanceRecord)
            {
                System.Diagnostics.Debug.WriteLine(mark.Artist!.Name + " - " + mark.Attended);
            }
        }
    }
}

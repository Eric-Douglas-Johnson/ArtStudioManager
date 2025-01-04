
namespace ArtStudioManager.Components.Models
{
    public class ArtClass
    {
        public Guid Id { get; private set; }
        public ArtClassType Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now;
        public decimal Cost { get; set; }
        public Discount? MemberDiscount { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Material> Materials { get; set; }
        public AttendanceRecord AttendanceRecord { get; set; }

        public ArtClass(Guid id)
        {
            Id = id;
            Instructors = new List<Instructor>();
            Artists = new List<Artist>();
            Materials = new List<Material>();
            AttendanceRecord = new AttendanceRecord();
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
                var memberCount = Artists.Where(x => x.GetArtistType() == ArtistType.Member).Count();
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
            if (Instructors != null && Instructors.Count > 0)
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
            foreach (var mark in AttendanceRecord.Attendances)
            {
                System.Diagnostics.Debug.WriteLine(mark.Artist!.Name + " - " + mark.Attended);
            }
        }
    }
}

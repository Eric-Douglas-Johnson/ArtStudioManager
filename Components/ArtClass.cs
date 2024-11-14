
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
        public ICollection<Member>? Members { get; set; }
        public ICollection<NonMember>? NonMembers { get; set; }
        public ICollection<Material>? Materials { get; set; }
       
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

            if (Members != null && Members.Count > 0)
            {
                decimal memberCost;

                if (MemberDiscount is Discount discount)
                {
                    memberCost = Cost - MemberDiscount.GetAmount();
                }
                else
                {
                    memberCost = Cost;
                }

                totalDollars = Members.Count * memberCost;
            }

            if (NonMembers != null && NonMembers.Count > 0)
            {
                totalDollars += NonMembers.Count * Cost;
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
    }
}


namespace ArtStudioManager.Components
{
    public class ArtClass
    {
        public Guid Id { get; private set; }
        public ClassType? Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateAndTime { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<Member>? Members { get; set; }
        public List<Customer>? Customers { get; set; }
        public decimal? CostPerMember { get; set; }
        public decimal? CostPerCustomer { get; set; }

        public ArtClass()
        {
            Id = Guid.NewGuid();
        }

        public decimal? GetTotalDollars()
        {
            decimal? totalDollars = 0;

            if (Members != null && Members.Count > 0)
            {
                totalDollars = Members.Count * CostPerMember;
            }

            if (Customers != null && Customers.Count > 0)
            {
                totalDollars += Customers.Count * CostPerCustomer;
            }

            return totalDollars;
        }
    }
}

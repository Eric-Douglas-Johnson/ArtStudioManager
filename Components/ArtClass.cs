
using System.ComponentModel.DataAnnotations;

namespace ArtStudioManager.Components
{
    public class ArtClass
    {
        private decimal _costPerMember;
        private decimal _costPerCustomer;

        public Guid Id { get; private set; }
        public ClassType? Type { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime? DateAndTime { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<Member>? Members { get; set; }
        public List<Customer>? Customers { get; set; }

        [Required]
        [Range(0, 9999.99)]
        public decimal CostPerMember
        {
            get { return _costPerMember; }
            set
            {
                _costPerMember = Math.Round(value, 2);
            }
        }

        [Required]
        [Range(0, 9999.99)]
        public decimal CostPerCustomer
        {
            get { return _costPerCustomer; }
            set
            {
                _costPerCustomer = Math.Round(value, 2);
            }
        }

        public ArtClass()
        {
            Id = Guid.NewGuid();
        }

        public ArtClass(Guid id, IDataLoader<ArtClass> dataLoader)
        {
            Id = id;
            dataLoader.Load(this);
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


using ArtStudioManager.Components;

namespace UnitTesting
{
    public class ArtClassTests
    {
        private Random _random;
        private Array _classTypes;

        public ArtClassTests()
        {
            _random = new Random();
            _classTypes = Enum.GetValues(typeof(ClassType));
        }

        [Fact]
        public void GetTotalDollars_ReturnsZero_WhenNoOneSignedUp()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Members = new List<Member>(),
                NonMembers = new List<NonMember>(),
                Cost = 45.50m,
                MemberDiscount = new FlatRateDiscount(35m)
            };

            Assert.True(artClass.GetTotalDollars() == 0);
        }

        [Fact]
        public void GetTotalDollars_ReturnsValue_WhenMemberSignedUp()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Members = new List<Member> { new Member() { Name = "Eric Johnson" } },
                NonMembers = new List<NonMember>(),
                Cost = 45.50m,
                MemberDiscount = new FlatRateDiscount(35m)
            };

            Assert.True(artClass.GetTotalDollars() > 0);
        }

        [Fact]
        public void GetTotalDollars_ReturnsValue_WhenCustomerSignedUp()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Members = new List<Member>(),
                NonMembers = new List<NonMember> { new NonMember { Name = "Some Customer" } },
                Cost = 45.50m,
                MemberDiscount = new FlatRateDiscount(35m)
            };

            Assert.True(artClass.GetTotalDollars() > 0);
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenBothTypesSignedUp()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Members = new List<Member> { new Member { Name = "Eric Johnson" } },
                NonMembers = new List<NonMember> { new NonMember { Name = "Some Customer" }, new NonMember { Name = "Another Customer" } },
                Cost = 10.25m,
                MemberDiscount = new FlatRateDiscount(5.75m)
            };

            // 1 member * CostPerMember = 10.25, 2 customers * CostPerCustomer = 11.50
            Assert.Equal(21.75m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ReturnsRounded_WhenCosHasTooManyDecimalPlaces()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Members = new List<Member> { new Member { Name = "Eric Johnson" } },
                NonMembers = new List<NonMember> { new NonMember { Name = "Some Customer" }, new NonMember { Name = "Another Customer" } },
                Cost = 10.202m,
                MemberDiscount = new FlatRateDiscount(5.755m)
            };

            // 1 member * CostPerMember rounded down = 10.20, 2 customers * CostPerCustomer rounded up = 11.52
            Assert.Equal(21.72m, artClass.GetTotalDollars());
        }
    }
}
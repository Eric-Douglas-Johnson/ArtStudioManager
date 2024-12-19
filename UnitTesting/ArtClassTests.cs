
using ArtStudioManager.Components.Models;
using ArtStudioManager.Components.Factories;

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
        public void GetTotalDollars_ReturnsCorrectNonRoundedValue()
        {
            var artClass = ArtClassFactory.Create();
            artClass.Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = "Name of Class";
            artClass.Description = "Description of specific class";
            artClass.Start = DateTime.Now;
            artClass.End = DateTime.Now;
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } };

            artClass.Artists = new List<Artist> {
            new Member { Name = "Eric Johnson" },
            new NonMember { Name = "Some Customer" },
            new NonMember { Name = "Another Customer" } };

            artClass.Cost = 10.202m;
            artClass.MemberDiscount = new FlatRateDiscount(5.755m);

            // 1 member * (10.202 - 5.755) + 2 nonmembers * 10.202 --> non-rounded equals 24.851
            Assert.Equal(24.851m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ReturnsZero_WhenNoOneSignedUp()
        {
            var artClass = ArtClassFactory.Create();
            artClass.Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = "Name of Class";
            artClass.Description = "Description of specific class";
            artClass.Start = DateTime.Now;
            artClass.End = DateTime.Now;
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } };
            artClass.Artists = new List<Artist>();
            artClass.Cost = 45.50m;
            artClass.MemberDiscount = new FlatRateDiscount(35m);

            Assert.True(artClass.GetTotalDollars() == 0);
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenDiscountIsNull()
        {
            var artClass = ArtClassFactory.Create();
            artClass.Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = "Name of Class";
            artClass.Description = "Description of specific class";
            artClass.Start = DateTime.Now;
            artClass.End = DateTime.Now;
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } };
            artClass.Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } };
            artClass.Cost = 45.50m;

            // One member no discount, and one nonmember, so total cost should be 2 * Cost
            Assert.Equal(91m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenDiscountIsFlatRateAndZero()
        {
            var artClass = ArtClassFactory.Create();
            artClass.Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = "Name of Class";
            artClass.Description = "Description of specific class";
            artClass.Start = DateTime.Now;
            artClass.End = DateTime.Now;
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } };
            artClass.Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } };
            artClass.Cost = 45.50m;
            artClass.MemberDiscount = new FlatRateDiscount(0);

            // One member no discount, and one nonmember, so total cost should be 2 * Cost
            Assert.Equal(91m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenDiscountIsPercentageAndZero()
        {
            var artClass = ArtClassFactory.Create();
            artClass.Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = "Name of Class";
            artClass.Description = "Description of specific class";
            artClass.Start = DateTime.Now;
            artClass.End = DateTime.Now;
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } };
            artClass.Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } };
            artClass.Cost = 45.50m;
            artClass.MemberDiscount = new PercentageDiscount(45.50m, 0);

            // One member no discount, and one nonmember, so total cost should be 2 * Cost
            Assert.Equal(91m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenValidFlatRateDiscount()
        {
            var artClass = ArtClassFactory.Create();
            artClass.Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = "Name of Class";
            artClass.Description = "Description of specific class";
            artClass.Start = DateTime.Now;
            artClass.End = DateTime.Now;
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } };

            artClass.Artists = new List<Artist> {
                    new Member { Name = "Eric Johnson" },
                    new NonMember { Name = "Some Customer" },
                    new NonMember { Name = "Another Customer" } };

            artClass.Cost = 50.50m;
            artClass.MemberDiscount = new FlatRateDiscount(10.50m);

            // 1 member * (Cost - MemberDiscount) + 2 nonmembers * Cost
            Assert.Equal(141m, artClass.GetTotalDollars());
        }
    }
}
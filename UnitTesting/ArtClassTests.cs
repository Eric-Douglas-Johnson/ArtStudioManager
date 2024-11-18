
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
        public void GetTotalDollars_ReturnsCorrectNonRoundedValue()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },

                Artists = new List<Artist> { 
                    new Member { Name = "Eric Johnson" },
                    new NonMember { Name = "Some Customer" },
                    new NonMember { Name = "Another Customer" } },

                Cost = 10.202m,
                MemberDiscount = new FlatRateDiscount(5.755m)
            };

            // 1 member * (10.202 - 5.755) + 2 nonmembers * 10.202 --> non-rounded equals 24.851
            Assert.Equal(24.851m, artClass.GetTotalDollars());
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
                Artists = new List<Artist>(),
                Cost = 45.50m,
                MemberDiscount = new FlatRateDiscount(35m)
            };

            Assert.True(artClass.GetTotalDollars() == 0);
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenDiscountIsNull()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } },
                Cost = 45.50m
            };

            // One member no discount, and one nonmember, so total cost should be 2 * Cost
            Assert.Equal(91m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenDiscountIsFlatRateAndZero()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } },
                Cost = 45.50m,
                MemberDiscount = new FlatRateDiscount(0)
            };

            // One member no discount, and one nonmember, so total cost should be 2 * Cost
            Assert.Equal(91m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenDiscountIsPercentageAndZero()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } },
                Cost = 45.50m,
                MemberDiscount = new PercentageDiscount(45.50m, 0)
            };

            // One member no discount, and one nonmember, so total cost should be 2 * Cost
            Assert.Equal(91m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ThrowsArgEx_WhenDiscountIsPercentageAndCostIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } },
                Cost = 45.50m,
                MemberDiscount = new PercentageDiscount(-45.50m, 0)
            });
        }

        [Fact]
        public void GetTotalDollars_ThrowsArgEx_WhenDiscountIsPercentageAndPercentageIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } },
                Cost = 45.50m,
                MemberDiscount = new PercentageDiscount(45.50m, -0.45m)
            });
        }

        [Fact]
        public void GetTotalDollars_ThrowsArgEx_WhenDiscountIsPercentageAndPercentageIsGreaterThanZero()
        {
            Assert.Throws<ArgumentException>(() => new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } },
                Cost = 45.50m,
                MemberDiscount = new PercentageDiscount(45.50m, 1.0001m)
            });
        }

        [Fact]
        public void GetTotalDollars_ReturnsCorrectValue_WhenValidFlatRateDiscount()
        {
            var artClass = new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },

                Artists = new List<Artist> { 
                    new Member { Name = "Eric Johnson" }, 
                    new NonMember { Name = "Some Customer" }, 
                    new NonMember { Name = "Another Customer" } },

                Cost = 50.50m,
                MemberDiscount = new FlatRateDiscount(10.50m)
            };

            // 1 member * (Cost - MemberDiscount) + 2 nonmembers * Cost
            Assert.Equal(141m, artClass.GetTotalDollars());
        }

        [Fact]
        public void GetTotalDollars_ThrowsArgEx_WhenDiscountIsFlatRateAndLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new ArtClass()
            {
                Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!,
                Name = "Name of Class",
                Description = "Description of specific class",
                Start = DateTime.Now,
                End = DateTime.Now,
                Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true }, new Instructor() { Name = "Rose" } },
                Artists = new List<Artist> { new Member { Name = "Eric Johnson" }, new NonMember { Name = "Some Customer" } },
                Cost = 45.50m,
                MemberDiscount = new FlatRateDiscount(-2.1m)
            });
        }
    }
}
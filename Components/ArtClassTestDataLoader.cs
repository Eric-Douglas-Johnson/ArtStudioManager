﻿
namespace ArtStudioManager.Components
{
    public class ArtClassTestDataLoader : IDataLoader<ArtClass>
    {
        private Random _random = new();
        private Array _classTypes = Enum.GetValues(typeof(ClassType));
        private Array _classNames = new[] { 
            "Record Acrylic Pour", "Acrylic Canvas", "Bowl Pottery", "Finnish Bracelet", "Dog Scratch", "Coffee Face" };

        public Task Load(ArtClass artClass)
        {
            artClass.Type = (ClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = (string)_classNames.GetValue(_random.Next(_classNames.Length))!;
            artClass.Description = "Any added description details";
            artClass.Start = DateTime.Now.AddDays(_random.Next(10));
            artClass.End = artClass.Start.AddHours(2);
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true } };

            artClass.Attendees = new List<Artist> { 
                new Member() { Name = "Eric" }, 
                new Member() { Name = "Paula" },
                new Member() { Name = "Carla" },
                new Member() { Name = "Linda" },
                new NonMember() { Name = "Bob" },
                new NonMember() { Name = "Steve" },
                new NonMember() { Name = "Trevor" },
            };

            artClass.Cost = (decimal)_random.Next(100);
            artClass.MemberDiscount = new FlatRateDiscount((decimal)_random.Next(100));

            artClass.Materials = new List<Material> { 
                new() { Name = "Some Material", Quantity = 2.5f },
                new() { Name = "Second Material", Quantity = 12.5f },
                new() { Name = "Other Material", Quantity = 33f },
                new() { Name = "Last Material", Quantity = 10.25f }
            };

            return Task.CompletedTask;
        }
    }
}


using ArtStudioManager.Components.Factories;
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Loaders
{
    public class ArtClassesTestDataLoader : ICollectionLoader<ArtClass>
    {
        private Random _random = new();
        private Array _classTypes = Enum.GetValues(typeof(ArtClassType));
        private Array _classNames = new[] {
            "Record Acrylic Pour", "Acrylic Canvas", "Bowl Pottery", "Finnish Bracelet", "Dog Scratch", "Coffee Face" };

        public void Load(ICollection<ArtClass> artClasses)
        {
            for (int i = 0; i < 10000; i++)
            {
                var artClass = ArtClassFactory.Create();
                artClass.Type = (ArtClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
                artClass.Name = (string)_classNames.GetValue(_random.Next(_classNames.Length))!;
                artClass.Description = "Any added description details";
                artClass.Start = DateTime.Now.AddDays(_random.Next(10));
                artClass.End = artClass.Start.AddHours(2);
                artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true } };

                artClass.Artists = new List<Artist> {
                    new Member() { Name = "Eric" },
                    new Member() { Name = "Paula" },
                    new Member() { Name = "Carla" },
                    new Member() { Name = "Linda" },
                    new NonMember() { Name = "Bob" },
                    new NonMember() { Name = "Steve" },
                    new NonMember() { Name = "Trevor" },
                };

                artClass.Cost = _random.Next(100);
                artClass.MemberDiscount = new FlatRateDiscount(_random.Next(100));

                artClass.Materials = new List<Material> {
                    new() { Name = "Some Material", Quantity = 2.5m, Cost = _random.Next(10) },
                    new() { Name = "Second Material", Quantity = 12.5m, Cost = _random.Next(10) },
                    new() { Name = "Other Material", Quantity = 33m, Cost = _random.Next(10) },
                    new() { Name = "Last Material", Quantity = 10.25m, Cost = _random.Next(10) }
                };

                artClass.AttendanceRecord = new AttendanceRecord();
                artClass.AttendanceRecord.AddAttendees(artClass.Artists);

                artClasses.Add(artClass);
            }
        }

        public Task LoadAsync(ICollection<ArtClass> artClasses)
        {
            for (int i = 0; i < 10000; i++)
            {
                var artClass = ArtClassFactory.Create();
                artClass.Type = (ArtClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
                artClass.Name = (string)_classNames.GetValue(_random.Next(_classNames.Length))!;
                artClass.Description = "Any added description details";
                artClass.Start = DateTime.Now.AddDays(_random.Next(10));
                artClass.End = artClass.Start.AddHours(2);
                artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true } };

                artClass.Artists = new List<Artist> {
                    new Member() { Name = "Eric" },
                    new Member() { Name = "Paula" },
                    new Member() { Name = "Carla" },
                    new Member() { Name = "Linda" },
                    new NonMember() { Name = "Bob" },
                    new NonMember() { Name = "Steve" },
                    new NonMember() { Name = "Trevor" },
                };

                artClass.Cost = _random.Next(100);
                artClass.MemberDiscount = new FlatRateDiscount(_random.Next(100));

                artClass.Materials = new List<Material> {
                    new() { Name = "Some Material", Quantity = 2.5m, Cost = _random.Next(10) },
                    new() { Name = "Second Material", Quantity = 12.5m, Cost = _random.Next(10) },
                    new() { Name = "Other Material", Quantity = 33m, Cost = _random.Next(10) },
                    new() { Name = "Last Material", Quantity = 10.25m, Cost = _random.Next(10) }
                };

                artClass.AttendanceRecord = new AttendanceRecord();
                artClass.AttendanceRecord.AddAttendees(artClass.Artists);

                artClasses.Add(artClass);
            }

            return Task.CompletedTask;
        }
    }
}

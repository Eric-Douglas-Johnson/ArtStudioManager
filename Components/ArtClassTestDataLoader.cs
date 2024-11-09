
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
            artClass.DateAndTime = DateTime.Now.AddDays(_random.Next(10));
            artClass.Instructors = new List<Instructor> { new Instructor() { Name = "Karen", IsPrimary = true } };
            artClass.Members = new List<Member> { new Member() { Name = "Eric" }, new Member() { Name = "Paula" } };
            artClass.Customers = new List<Customer> { new Customer() { Name = "Random Customer" } };
            artClass.CostPerMember = (decimal)_random.Next(100);
            artClass.CostPerCustomer = (decimal)_random.Next(100);

            return Task.CompletedTask;
        }
    }
}

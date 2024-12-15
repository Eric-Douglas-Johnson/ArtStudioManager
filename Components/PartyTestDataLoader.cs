
namespace ArtStudioManager.Components
{
    public class PartyTestDataLoader : IEntityLoader<ICollection<Party>>
    {
        private Random _random = new();
        private Array _partyNames = new[] {
            "Birthday, Painting", "Birthday, Drawing", "Christmas, Painting", "Cat's Birthday", "Birthday", "Family Misc" };

        public Task Load(ICollection<Party> parties)
        {
            for (int i = 0; i < 10000; i++)
            {
                var startDateTime = DateTime.Now.AddDays(_random.Next(10));

                var party = new Party
                {
                    Name = (string)_partyNames.GetValue(_random.Next(_partyNames.Length))!,
                    Description = "Some description of the party.",
                    Start = startDateTime,
                    End = startDateTime.AddHours(2),
                    ContactName = "This the person who set up the party.",
                    ContactPhoneNumber = "Call this number to talk to the party contact.",
                    ContactEmail = "Send email to this address to communicate with the party contact.",
                    AttendeeCount = _random.Next(30),
                    EmployeeName = "The employee who is overseeing and preparing the party.",
                    DollarAmountCharged = _random.Next(500),

                    Materials = new List<Material>
                    {
                        new Material { Cost = _random.Next(50) },
                        new Material { Cost = _random.Next(10) },
                        new Material { Cost = _random.Next(100) },
                        new Material { Cost = _random.Next(5) },
                        new Material { Cost = _random.Next(20) }
                    }
                };

                parties.Add(party);
            }

            return Task.CompletedTask;
        }
    }
}

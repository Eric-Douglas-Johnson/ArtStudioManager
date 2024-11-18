﻿
namespace ArtStudioManager.Components
{
    public class ArtistTestLoader : IDataLoader<ICollection<Artist>>
    {
        private Random _random = new();
        private Array _memberTypes = Enum.GetValues(typeof(Member.MembershipType));
        private Array _artistNames = new[] {
            "Bob Rye", "Eric Johnson", "Paula Ramos", "Sandy Shores", "Jane Doe", "Steve Oreeno", "Trevor McLovin" };
        private Array _testEmails = new[] {
            "someguy@yahoo.com", "aladyfromhere@gmail.com", "noidea@outlook.com", "and_again@yahoo.com" };

        public Task Load(ICollection<Artist> artists)
        {
            for (int i = 0; i < 10000; i++)
            {
                if (i % 2 == 0)
                {
                    var artist = new Member();
                    artist.Name = (string)_artistNames.GetValue(_random.Next(_artistNames.Length))!;
                    artist.MemberType = (Member.MembershipType)_memberTypes.GetValue(_random.Next(_memberTypes.Length))!;
                    artist.Email = (string)_testEmails.GetValue(_random.Next(_testEmails.Length))!;
                    artists.Add(artist);
                }
                else
                {
                    var artist = new NonMember();
                    artist.Name = (string)_artistNames.GetValue(_random.Next(_artistNames.Length))!;
                    artist.Email = (string)_testEmails.GetValue(_random.Next(_testEmails.Length))!;
                    artists.Add(artist);
                }
            }

            return Task.CompletedTask;
        }
    }
}


namespace ArtStudioManager.Components
{
    public class MembersTestCollectionLoader : ICollectionLoader<Member>
    {
        public Task Load(ICollection<Member> collectionToLoadInto)
        {
            collectionToLoadInto.Add(
                new Member() { 
                    MemberId = Guid.NewGuid().ToString(),
                    Name = "Eric Johnson",
                    MemberType = Member.MembershipType.Family,
                    DateJoined = DateOnly.FromDateTime(DateTime.Now),
                    Email = "e_d_johnson2003@yahoo.com"
                }
            );

            collectionToLoadInto.Add(
                new Member()
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Name = "Paula Ramos",
                    MemberType = Member.MembershipType.Single,
                    DateJoined = DateOnly.FromDateTime(DateTime.Now),
                    Email = "someemail@yahoo.com"
                }
            );

            collectionToLoadInto.Add(
                new Member()
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Name = "Bob Rye",
                    MemberType = Member.MembershipType.Family,
                    DateJoined = DateOnly.FromDateTime(DateTime.Now),
                    Email = "bobrye@yahoo.com"
                }
            );

            collectionToLoadInto.Add(
                new Member()
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Name = "Apple Gato",
                    MemberType = Member.MembershipType.Student,
                    DateJoined = DateOnly.FromDateTime(DateTime.Now),
                    Email = "apple@yahoo.com"
                }
            );

            return Task.CompletedTask;
        }
    }
}

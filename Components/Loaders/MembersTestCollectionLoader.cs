﻿using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Loaders
{
    public class MembersTestCollectionLoader : ICollectionLoader<Member>
    {
        public void Load(ICollection<Member> collectionToLoadInto){
            collectionToLoadInto.Add(
                new Member()
                {
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
        }

        public Task LoadAsync(ICollection<Member> collectionObj)
        {
            throw new NotImplementedException();
        }
    }
}

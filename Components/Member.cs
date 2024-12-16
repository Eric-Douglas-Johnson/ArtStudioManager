﻿
namespace ArtStudioManager.Components
{
    public class Member : Artist
    {
        public enum MembershipType
        {
            Student,
            Single,
            Family
        }

        public string? MemberId { get; set; }      
        public MembershipType MemberType { get; set; }
        public DateOnly? DateJoined { get; set; }

        public Member() : base() { }

        public Member(IEntityLoader<Member> dataLoader)
        {
            dataLoader.Load(this);
        }

        public override ArtistType GetArtistType()
        {
            return ArtistType.Member;
        }
    }
}

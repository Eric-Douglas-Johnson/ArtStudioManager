
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using Microsoft.Extensions.Primitives;

namespace ArtStudioManager.Components.Loaders
{
    public class ArtClassFileLoader : IModelLoader<ArtClass>
    {
        private readonly string _artClassFolderPath;

        public ArtClassFileLoader(string artClassFolderPath)
        {
            _artClassFolderPath = artClassFolderPath;
        }

        public void Load(ArtClass artClass)
        {
            var targetFile = _artClassFolderPath + artClass.Id.ToString();
            if (!File.Exists(targetFile)) { throw new FileNotFoundException(); }

            using var fileStream = File.OpenRead(targetFile);
            using var reader = new StreamReader(fileStream);
            reader.ReadLine(); //first line is Id, which is already loaded

            if (!Enum.TryParse(reader.ReadLine(), out ArtClassType artClassType)) 
            { 
                throw new InvalidOperationException("Art class type is not valid"); 
            }

            artClass.Type = artClassType;
            artClass.Name = reader.ReadLine();
            artClass.Description = reader.ReadLine();

            long startTicks = long.Parse(reader.ReadLine()!);
            artClass.Start = new DateTime(startTicks);

            long endTicks = long.Parse(reader.ReadLine()!);
            artClass.End = new DateTime(endTicks);

            artClass.Cost = decimal.Parse(reader.ReadLine()!);

            string currentLine;
            while (!reader.EndOfStream)
            {
                currentLine = reader.ReadLine()!;

                if (currentLine == typeof(FlatRateDiscount).ToString())
                {
                    artClass.MemberDiscount = new FlatRateDiscount(decimal.Parse(reader.ReadLine()!));
                }
                else if (currentLine == typeof(PercentageDiscount).ToString())
                {
                    artClass.MemberDiscount = new PercentageDiscount(decimal.Parse(reader.ReadLine()!), decimal.Parse(reader.ReadLine()!));
                }
                else if (currentLine == typeof(Instructor).ToString())
                {
                    var instructorId = Guid.Parse(reader.ReadLine()!);
                    var instructor = new Instructor(instructorId);
                    instructor.IsPrimary = bool.Parse(reader.ReadLine()!);
                    instructor.Name = reader.ReadLine()!;
                    instructor.Email = reader.ReadLine()!;
                    artClass.Instructors.Add(instructor);
                }
                else if (currentLine == typeof(Member).ToString())
                {
                    var memberId = Guid.Parse(reader.ReadLine()!);
                    var member = new Member(memberId);
                    member.Name = reader.ReadLine()!;
                    member.PrimaryPhone = reader.ReadLine()!;
                    member.SecondaryPhone = reader.ReadLine()!;
                    member.StreetAddress = reader.ReadLine()!;
                    member.City = reader.ReadLine()!;
                    member.State = reader.ReadLine()!;
                    member.Zip = reader.ReadLine()!;
                    member.Email = reader.ReadLine()!;
                    member.ReferredBy = reader.ReadLine()!;

                    if (DateOnly.TryParse(reader.ReadLine()!, out var birthDate))
                    {
                        member.Birthday = birthDate;
                    }
                    
                    member.Groups = reader.ReadLine()!;
                    member.MemberId = reader.ReadLine()!;

                    if (!Enum.TryParse(reader.ReadLine(), out MembershipType memberType))
                    {
                        throw new InvalidOperationException("Membership type is not valid");
                    }

                    member.MemberType = memberType;

                    if (DateOnly.TryParse(reader.ReadLine()!, out var memberDateJoined))
                    {
                        member.DateJoined = memberDateJoined;
                    }

                    artClass.Artists.Add(member);
                }

                else if (currentLine == typeof(NonMember).ToString())
                {
                    var nonMemberId = Guid.Parse(reader.ReadLine()!);
                    var nonMember = new NonMember(nonMemberId);
                    nonMember.Name = reader.ReadLine()!;
                    nonMember.PrimaryPhone = reader.ReadLine()!;
                    nonMember.SecondaryPhone = reader.ReadLine()!;
                    nonMember.StreetAddress = reader.ReadLine()!;
                    nonMember.City = reader.ReadLine()!;
                    nonMember.State = reader.ReadLine()!;
                    nonMember.Zip = reader.ReadLine()!;
                    nonMember.Email = reader.ReadLine()!;
                    nonMember.ReferredBy = reader.ReadLine()!;

                    if (DateOnly.TryParse(reader.ReadLine()!, out var birthDate))
                    {
                        nonMember.Birthday = birthDate;
                    }

                    nonMember.Groups = reader.ReadLine()!;

                    artClass.Artists.Add(nonMember);
                }
                else if (currentLine == typeof(Material).ToString())
                {
                    var material = new Material()
                    {
                        Name = reader.ReadLine()!,
                        Description = reader.ReadLine()!,
                        Quantity = decimal.Parse(reader.ReadLine()!),
                        Cost = decimal.Parse(reader.ReadLine()!)
                    };

                    artClass.Materials.Add(material);
                }
                else if (currentLine == typeof(Attendance).ToString())
                {
                    var attendeeId = Guid.Parse(reader.ReadLine()!);
                    var artistType = reader.ReadLine()!;
                    var artistName = reader.ReadLine()!;
                    var primPhone = reader.ReadLine()!;
                    var secPhone = reader.ReadLine()!;
                    var address = reader.ReadLine()!;
                    var city = reader.ReadLine()!;
                    var state = reader.ReadLine()!;
                    var zip = reader.ReadLine()!;
                    var email = reader.ReadLine()!;
                    var referredBy = reader.ReadLine()!;

                    DateOnly? birthday = null;
                    if (DateOnly.TryParse(reader.ReadLine()!, out var birthDate))
                    {
                        birthday = birthDate;
                    }

                    var groups = reader.ReadLine()!;

                    string nextLine = reader.ReadLine()!;

                    if (nextLine == typeof(Member).ToString())
                    {
                        var member = new Member(attendeeId);
                        member.Name = artistName;
                        member.PrimaryPhone = primPhone;
                        member.SecondaryPhone = secPhone;
                        member.StreetAddress = address;
                        member.City = city;
                        member.State = state;
                        member.Zip = zip;
                        member.Email = email;
                        member.ReferredBy = referredBy;
                        member.Birthday = birthday;
                        member.Groups = groups;

                        member.MemberId = reader.ReadLine()!;

                        if (!Enum.TryParse(reader.ReadLine(), out MembershipType memberType))
                        {
                            throw new InvalidOperationException("Membership type is not valid");
                        }

                        member.MemberType = memberType;

                        if (DateOnly.TryParse(reader.ReadLine()!, out var memberDateJoined))
                        {
                            member.DateJoined = memberDateJoined;
                        }

                        bool attended = bool.Parse(reader.ReadLine()!);
                        artClass.AttendanceRecord.AddAttendance(member, attended);
                    }
                    else
                    {
                        var nonMember = new NonMember(attendeeId);
                        nonMember.Name = artistName;
                        nonMember.PrimaryPhone = primPhone;
                        nonMember.SecondaryPhone = secPhone;
                        nonMember.StreetAddress = address;
                        nonMember.City = city;
                        nonMember.State = state;
                        nonMember.Zip = zip;
                        nonMember.Email = email;
                        nonMember.ReferredBy = referredBy;
                        nonMember.Birthday = birthday;
                        nonMember.Groups = groups;

                        bool attended = bool.Parse(nextLine);
                        artClass.AttendanceRecord.AddAttendance(nonMember, attended);
                    }
                }
            }
        }

        public Task LoadAsync(ArtClass entityObj)
        {
            throw new NotImplementedException();
        }
    }
}

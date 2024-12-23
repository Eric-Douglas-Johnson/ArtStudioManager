using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Savers
{
    public class ArtClassFileSaver : IModelSaver<ArtClass>
    {
        public void Save(ArtClass artClass)
        {
            var fileName = Environment.CurrentDirectory + @"\Files\ArtClasses\" + artClass.Id.ToString();
            using var fileStream = new FileStream(fileName, FileMode.Create);
            using var writer = new StreamWriter(fileStream);

            writer.WriteLine(artClass.Id.ToString());
            writer.WriteLine(artClass.Type.ToString());
            writer.WriteLine(artClass.Name ?? string.Empty);
            writer.WriteLine(artClass.Description ?? string.Empty);
            writer.WriteLine(artClass.Start.ToString());
            writer.WriteLine(artClass.End.ToString());
            writer.WriteLine(artClass.Cost.ToString());

            if (artClass.MemberDiscount != null)
            {
                writer.WriteLine(artClass.MemberDiscount.GetType());

                if (artClass.MemberDiscount.GetType() == typeof(FlatRateDiscount))
                {
                    var flatRateInstance = (FlatRateDiscount)artClass.MemberDiscount;
                    writer.WriteLine(flatRateInstance.FlatRate.ToString());
                }
                else
                {
                    var percentInstance = (PercentageDiscount)artClass.MemberDiscount;
                    writer.WriteLine(percentInstance.Cost.ToString());
                    writer.WriteLine(percentInstance.Percentage.ToString());
                }
            }

            foreach (var instructor in artClass.Instructors)
            {
                var type = instructor.GetType().ToString();
                writer.WriteLine(type);

                writer.WriteLine(instructor.Id.ToString());
                writer.WriteLine(instructor.IsPrimary);
                writer.WriteLine(instructor.Name ?? string.Empty);
                writer.WriteLine(instructor.Email ?? string.Empty);
            }

            foreach (var artist in artClass.Artists)
            {
                writer.WriteLine(artist.GetType());

                writer.WriteLine(artist.Id.ToString());
                writer.WriteLine(artist.GetArtistType().ToString());
                writer.WriteLine(artist.Name ?? string.Empty);
                writer.WriteLine(artist.PrimaryPhone ?? string.Empty);
                writer.WriteLine(artist.SecondaryPhone ?? string.Empty);
                writer.WriteLine(artist.StreetAddress ?? string.Empty);
                writer.WriteLine(artist.City ?? string.Empty);
                writer.WriteLine(artist.State ?? string.Empty);
                writer.WriteLine(artist.Zip ?? string.Empty);
                writer.WriteLine(artist.Email ?? string.Empty);
                writer.WriteLine(artist.ReferredBy ?? string.Empty);
                writer.WriteLine(artist.Birthday.ToString() ?? string.Empty);
                writer.WriteLine(artist.Groups);

                if (artist.GetType() == typeof(Member))
                {
                    var member = (Member)artist;
                    writer.WriteLine(member.MemberId);
                    writer.WriteLine(member.MemberType.ToString());
                    writer.WriteLine(member.DateJoined.ToString());
                }
            }

            foreach (var material in artClass.Materials)
            {
                writer.WriteLine(material.GetType());

                writer.WriteLine(material.Name ?? string.Empty);
                writer.WriteLine(material.Description ?? string.Empty);
                writer.WriteLine(material.Quantity);
                writer.WriteLine(material.Cost);
            }

            foreach (var attendance in artClass.Attendance.Attendances)
            {
                writer.WriteLine(attendance.GetType());

                writer.WriteLine(attendance.Artist.Id.ToString());
                writer.WriteLine(attendance.Artist.GetArtistType().ToString());
                writer.WriteLine(attendance.Artist.Name ?? string.Empty);
                writer.WriteLine(attendance.Artist.PrimaryPhone ?? string.Empty);
                writer.WriteLine(attendance.Artist.SecondaryPhone ?? string.Empty);
                writer.WriteLine(attendance.Artist.StreetAddress ?? string.Empty);
                writer.WriteLine(attendance.Artist.City ?? string.Empty);
                writer.WriteLine(attendance.Artist.State ?? string.Empty);
                writer.WriteLine(attendance.Artist.Zip ?? string.Empty);
                writer.WriteLine(attendance.Artist.Email ?? string.Empty);
                writer.WriteLine(attendance.Artist.ReferredBy ?? string.Empty);
                writer.WriteLine(attendance.Artist.Birthday.ToString() ?? string.Empty);
                writer.WriteLine(attendance.Artist.Groups);

                if (attendance.Artist.GetType() == typeof(Member))
                {
                    var member = (Member)attendance.Artist;
                    writer.WriteLine(member.MemberId);
                    writer.WriteLine(member.MemberType.ToString());
                    writer.WriteLine(member.DateJoined.ToString());
                }

                writer.WriteLine(attendance.Attended);
            }

            writer.Flush();
            writer.Close();
        }

        public async Task SaveAsync(ArtClass artClass)
        {
            var fileName = Environment.CurrentDirectory + @"\Files\ArtClasses\" + artClass.Id.ToString();
            await using var fileStream = File.Create(fileName);
            using var writer = new StreamWriter(fileStream);

            writer.WriteLine(artClass.Id.ToString());
            writer.WriteLine(artClass.Type.ToString());
            writer.WriteLine(artClass.Name ?? string.Empty);
            writer.WriteLine(artClass.Description ?? string.Empty);
            writer.WriteLine(artClass.Start.ToString());
            writer.WriteLine(artClass.End.ToString());
            writer.WriteLine(artClass.Cost.ToString());

            if (artClass.MemberDiscount != null)
            {
                writer.WriteLine(artClass.MemberDiscount.GetType());

                if (artClass.MemberDiscount.GetType() == typeof(FlatRateDiscount))
                {
                    var flatRateInstance = (FlatRateDiscount)artClass.MemberDiscount;
                    writer.WriteLine(flatRateInstance.FlatRate.ToString());
                }
                else
                {
                    var percentInstance = (PercentageDiscount)artClass.MemberDiscount;
                    writer.WriteLine(percentInstance.Cost.ToString());
                    writer.WriteLine(percentInstance.Percentage.ToString());
                }
            }

            foreach (var instructor in artClass.Instructors)
            {
                writer.WriteLine(instructor.GetType());

                writer.WriteLine(instructor.Id.ToString());
                writer.WriteLine(instructor.IsPrimary);
                writer.WriteLine(instructor.Name ?? string.Empty);
                writer.WriteLine(instructor.Email ?? string.Empty);
            }

            foreach (var artist in artClass.Artists)
            {
                writer.WriteLine(artist.GetType());

                writer.WriteLine(artist.Id.ToString());
                writer.WriteLine(artist.GetArtistType().ToString());
                writer.WriteLine(artist.Name ?? string.Empty);
                writer.WriteLine(artist.PrimaryPhone ?? string.Empty);
                writer.WriteLine(artist.SecondaryPhone ?? string.Empty);
                writer.WriteLine(artist.StreetAddress ?? string.Empty);
                writer.WriteLine(artist.City ?? string.Empty);
                writer.WriteLine(artist.State ?? string.Empty);
                writer.WriteLine(artist.Zip ?? string.Empty);
                writer.WriteLine(artist.Email ?? string.Empty);
                writer.WriteLine(artist.ReferredBy ?? string.Empty);
                writer.WriteLine(artist.Birthday.ToString() ?? string.Empty);
                writer.WriteLine(artist.Groups);

                if (artist.GetType() == typeof(Member))
                {
                    var member = (Member)artist;
                    writer.WriteLine(member.MemberId);
                    writer.WriteLine(member.MemberType.ToString());
                    writer.WriteLine(member.DateJoined.ToString());
                }
            }

            foreach (var material in artClass.Materials)
            {
                writer.WriteLine(material.GetType());

                writer.WriteLine(material.Name ?? string.Empty);
                writer.WriteLine(material.Description ?? string.Empty);
                writer.WriteLine(material.Quantity);
                writer.WriteLine(material.Cost);
            }

            foreach (var attendance in artClass.Attendance.Attendances)
            {
                writer.WriteLine(attendance.GetType());

                writer.WriteLine(attendance.Artist.Id.ToString());
                writer.WriteLine(attendance.Artist.GetArtistType().ToString());
                writer.WriteLine(attendance.Artist.Name ?? string.Empty);
                writer.WriteLine(attendance.Artist.PrimaryPhone ?? string.Empty);
                writer.WriteLine(attendance.Artist.SecondaryPhone ?? string.Empty);
                writer.WriteLine(attendance.Artist.StreetAddress ?? string.Empty);
                writer.WriteLine(attendance.Artist.City ?? string.Empty);
                writer.WriteLine(attendance.Artist.State ?? string.Empty);
                writer.WriteLine(attendance.Artist.Zip ?? string.Empty);
                writer.WriteLine(attendance.Artist.Email ?? string.Empty);
                writer.WriteLine(attendance.Artist.ReferredBy ?? string.Empty);
                writer.WriteLine(attendance.Artist.Birthday.ToString() ?? string.Empty);
                writer.WriteLine(attendance.Artist.Groups);

                if (attendance.Artist.GetType() == typeof(Member))
                {
                    var member = (Member)attendance.Artist;
                    writer.WriteLine(member.MemberId);
                    writer.WriteLine(member.MemberType.ToString());
                    writer.WriteLine(member.DateJoined.ToString());
                }

                writer.WriteLine(attendance.Attended);
            }

            writer.Flush();
            writer.Close();
        }
    }
}


using ArtStudioManager.Components.Models;
using ArtStudioManager.Components.Factories;
using ArtStudioManager.Components.Savers;
using ArtStudioManager.Components.Loaders;

namespace UnitTesting
{
    public class ArtClassFileTests
    {
        private Random _random;
        private Array _classTypes;

        public ArtClassFileTests()
        {
            _random = new Random();
            _classTypes = Enum.GetValues(typeof(ArtClassType));
        }

        [Fact]
        public void FileLoad_LoadsCorrectSavedData()
        {
            // Arrange
            var artClass = ArtClassFactory.Create();
            artClass.Type = (ArtClassType)_classTypes.GetValue(_random.Next(_classTypes.Length))!;
            artClass.Name = "Test Class for file tests";
            artClass.Description = "Description of specific class";
            artClass.Start = DateTime.Now;
            artClass.End = DateTime.Now;
            artClass.Cost = 50m;
            artClass.MemberDiscount = new FlatRateDiscount(5m);

            artClass.Instructors = new List<Instructor> 
            {
                new() { Name = "Karen", IsPrimary = true }, 
                new() { Name = "Rose" }
            };

            artClass.Artists = new List<Artist> 
            {
                new Member { Name = "Eric Johnson" },
                new NonMember { Name = "Some NonMember" },
                new NonMember { Name = "Another NonMember" } 
            };

            artClass.Materials = new List<Material>
            {
                new Material() { Cost = 10, Name = "name 1", Quantity = 5, Description = "test desc 1" },
                new Material() { Cost = 100, Name = "name 2", Quantity = 1, Description = "test desc 2" },
                new Material() { Cost = 1, Name = "name 3", Quantity = 50, Description = "test desc 3" },
                new Material() { Cost = 15, Name = "name 4", Quantity = 15, Description = "test desc 4" },
                new Material() { Cost = 33, Name = "name 5", Quantity = 3, Description = "test desc 5" }
            };

            var attendanceRecord = new AttendanceRecord();
            attendanceRecord.AddAttendees(artClass.Artists);
            artClass.AttendanceRecord = attendanceRecord;

            // Act
            var artClassSaver = new ArtClassFileSaver(@"C:\Users\e_d_j\OneDrive\Desktop\Code\ArtStudioManager\Files\ArtClasses\Tests\");
            artClassSaver.Save(artClass);

            var artClassLoader = new ArtClassFileLoader(@"C:\Users\e_d_j\OneDrive\Desktop\Code\ArtStudioManager\Files\ArtClasses\Tests\");
            var loadedArtClassInstance = ArtClassFactory.Create(artClass.Id, artClassLoader);

            // Assert
            Assert.Equal(artClass.Id, loadedArtClassInstance.Id);
            Assert.Equal(artClass.Type, loadedArtClassInstance.Type);
            Assert.Equal(artClass.Name, loadedArtClassInstance.Name);
            Assert.Equal(artClass.Description, loadedArtClassInstance.Description);
            Assert.Equal(artClass.Start, loadedArtClassInstance.Start);
            Assert.Equal(artClass.End, loadedArtClassInstance.End);
            Assert.Equal(artClass.Cost, loadedArtClassInstance.Cost);
            Assert.Equal(artClass.MemberDiscount.GetAmount(), loadedArtClassInstance.MemberDiscount!.GetAmount());

            foreach (var instructor in artClass.Instructors)
            {
                Assert.True(InstructorFound(loadedArtClassInstance.Instructors, instructor));
            }

            foreach (var artist in artClass.Artists)
            {
                Assert.True(ArtistFound(loadedArtClassInstance.Artists, artist));
            }

            foreach (var material in artClass.Materials)
            {
                Assert.True(MaterialFound(loadedArtClassInstance.Materials, material));
            }

            foreach (var attendance in artClass.AttendanceRecord.Attendances)
            {
                Assert.True(AttendanceFound(loadedArtClassInstance.AttendanceRecord.Attendances, attendance));
            }
        }

        private bool InstructorFound(ICollection<Instructor> instructors, Instructor targetInstructor)
        {
            foreach (var instructor in instructors)
            {
                var instructorName = instructor.Name ?? string.Empty;
                var targetInstructorName = targetInstructor.Name ?? string.Empty;
                var instructorEmail = instructor.Email ?? string.Empty;
                var targetInstructorEmail = targetInstructor.Email ?? string.Empty;

                if (instructor.Id == targetInstructor.Id && 
                    instructorName == targetInstructorName && 
                    instructor.IsPrimary == targetInstructor.IsPrimary &&
                    instructorEmail == targetInstructorEmail)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ArtistFound(ICollection<Artist> artists, Artist targetArtist)
        {
            foreach (var artist in artists)
            {
                var artistName = artist.Name ?? string.Empty;
                var targetArtistName = targetArtist.Name ?? string.Empty;

                var artistPrimaryPhone = artist.PrimaryPhone ?? string.Empty;
                var targetArtistPrimaryPhone = targetArtist.PrimaryPhone ?? string.Empty;

                var artistSecondaryPhone = artist.SecondaryPhone ?? string.Empty;
                var targetArtistSecondaryPhone = targetArtist.SecondaryPhone ?? string.Empty;

                var artistStreetAddress = artist.StreetAddress ?? string.Empty;
                var targetArtistStreetAddress = targetArtist.StreetAddress ?? string.Empty;

                var artistCity = artist.City ?? string.Empty;
                var targetArtistCity = targetArtist.City ?? string.Empty;

                var artistState = artist.State ?? string.Empty;
                var targetArtistState = targetArtist.State ?? string.Empty;

                var artistZip = artist.Zip ?? string.Empty;
                var targetArtistZip = targetArtist.Zip ?? string.Empty;

                var artistEmail = artist.Email ?? string.Empty;
                var targetArtistEmail = targetArtist.Email ?? string.Empty;

                var artistReferredBy = artist.ReferredBy ?? string.Empty;
                var targetArtistReferredBy = targetArtist.ReferredBy ?? string.Empty;

                var artistBirthday = artist.Birthday ?? DateOnly.MaxValue;
                var targetArtistBirthday = targetArtist.Birthday ?? DateOnly.MaxValue;

                if (artist.Id == targetArtist.Id &&
                    artistPrimaryPhone == targetArtistPrimaryPhone &&
                    artistSecondaryPhone == targetArtistSecondaryPhone &&
                    artistStreetAddress == targetArtistStreetAddress &&
                    artistCity == targetArtistCity &&
                    artistState == targetArtistState &&
                    artistZip == targetArtistZip &&
                    artistEmail == targetArtistEmail &&
                    artistReferredBy == targetArtistReferredBy &&
                    artistBirthday == targetArtistBirthday)
                {
                    return true;
                }
            }

            return false;
        }

        private bool MaterialFound(ICollection<Material> materials, Material targetMaterial)
        {
            foreach (var material in materials)
            {
                var matName = material.Name ?? string.Empty;
                var targetMatName = targetMaterial.Name ?? string.Empty;

                var matDesc = material.Description ?? string.Empty;
                var targetMatDesc = targetMaterial.Description ?? string.Empty;

                if (matName == targetMatName &&
                    matDesc == targetMatDesc &&
                    material.Quantity == targetMaterial.Quantity &&
                    material.Cost == targetMaterial.Cost)
                {
                    return true;
                }
            }

            return false;
        }

        private bool AttendanceFound(ICollection<Attendance> attendances, Attendance targetAttendance)
        {
            foreach (var attendance in attendances)
            {
                if (attendance.Artist.Id == targetAttendance.Artist.Id &&
                    attendance.Attended == targetAttendance.Attended)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
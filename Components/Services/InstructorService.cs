using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using System.Collections.ObjectModel;

namespace ArtStudioManager.Components.Services
{
    public static class InstructorService
    {
        public static ICollection<Instructor> GetInstructors(ICollectionLoader<Instructor> instructorLoader)
        {
            var instructors = new Collection<Instructor>();
            instructorLoader.Load(instructors);
            return instructors;
        }
    }
}

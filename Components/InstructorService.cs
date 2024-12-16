
using System.Collections.ObjectModel;

namespace ArtStudioManager.Components
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

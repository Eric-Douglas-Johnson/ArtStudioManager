namespace ArtStudioManager.Components.Models
{
    public class Instructor
    {
        public Guid Id { get; set; }
        public bool IsPrimary { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public Instructor()
        {
            Id = Guid.NewGuid();
        }
    }
}

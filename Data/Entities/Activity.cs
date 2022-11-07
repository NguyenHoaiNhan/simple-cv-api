namespace SimpleCV.Data.Entities
{
    public class Activity
    {
        public int ActId { get; set; }
        public string? Position { get; set; }
        public string? Organization { get; set; }
        public string? City { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? ActivityType { get; set; }
        public string? ActivityTitle { get; set; }
        public virtual Description? RefDescription { get; set; }
        public virtual ICollection<CV>? CVs { get; set; }
    }
}
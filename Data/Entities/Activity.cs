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

        /// Config 1:1 relationship Activity : Description
        public virtual Description? RefDescription { get; set; }

        // Config n:1 relationship Activity:CVActivity
        public virtual ICollection<CVActivity>? CVActivities { get; set; }
    }
}
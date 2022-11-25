namespace SimpleCV.Data.Entities
{
    public class Activity
    {
        public int ActId { get; set; }
        public int CVId { get; set; }
        public string? Position { get; set; }
        public string? Organization { get; set; }
        public string? City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ActivityType { get; set; }

        /// Config 1:1 relationship Activity:Description
        public virtual Description? RefDescription { get; set; }

        /// Config 1:n relationship CV:Activity
        public virtual CV? RefCV { get; set; }
    }
}
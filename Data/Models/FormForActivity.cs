namespace SimpleCV.Data.Models
{
    public class FormForActivity
    {
        public FormForActivity()
        {
            if (Description != null)
                Description.ActivityId = ActId;
        }
        public int ActId { get; set; }
        public int CVId { get; set; }
        public string? Position { get; set; }
        public string? Organization { get; set; }
        public string? City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ActivityType { get; set; } = "custom";
        public TextForm? Description { get; set; }
    }
}
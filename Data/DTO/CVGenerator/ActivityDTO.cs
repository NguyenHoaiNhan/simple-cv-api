using SimpleCV.Data.Models;

namespace SimpleCV.Data.DTO.CVGenerator
{
    public class ActivityDTO
    {
        public int ActId { get; set; }
        public int CVId { get; set; }
        public string? SectionTitle { get; set; } = "Activity";
        public string? Position { get; set; }
        public string? Organization { get; set; }
        public string? City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ActivityType { get; set; } = "unknown";
        public TextForm? Description { get; set; }
    }
}
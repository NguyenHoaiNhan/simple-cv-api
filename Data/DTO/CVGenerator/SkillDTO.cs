using SimpleCV.Data.Models;

namespace SimpleCV.Data.DTO.CVGenerator
{
    public class SkillDTO
    {
        public int SkillId { get; set; }
        public string? SectionTitle { get; set; } = "Technical Skills";
        public string? SkillName { get; set; }
        public int? Level { get; set; }
    }
}
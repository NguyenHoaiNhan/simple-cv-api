namespace SimpleCV.Data.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public int? Level { get; set; }
        public string? SkillType { get; set; }
        public string? SkillTitle { get; set; }

        /// Config 1:n relationship CVSkill:Skill
        public virtual ICollection<CVSkill>? CVSkills { get; set; }
    }
}
namespace SimpleCV.Data.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillType { get; set; }

        /// Config 1:n relationship CVSkill:Skill
        public virtual ICollection<CVSkill>? CVSkills { get; set; }
    }
}
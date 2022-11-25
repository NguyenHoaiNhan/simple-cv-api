namespace SimpleCV.Data.Entities
{
    public class CVSkill
    {
        public int CVId { get; set; }
        public int SkillId { get; set; }
        public int? Level { get; set; }

        /// Config 1:n relationship Skill:CV
        public CV? RefCV { get; set; }

        /// Config 1:n relationship Skill:CVSkill
        public Skill? RefSkill { get; set; }
    }
}
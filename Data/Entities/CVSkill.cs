namespace SimpleCV.Data.Entities
{
    public class CVSkill
    {
        public int CVId;
        public int SkillId;

        /// Config 1:n relationship Skill:CV
        public int? FKCVId;
        public CV? RefCV;

        /// Config 1:n relationship Skill:CVSkill
        public int? FKSkillId;
        public Skill? RefSkill;
    }
}
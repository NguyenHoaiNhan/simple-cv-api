namespace SimpleCV.Data.Entities
{
    public class CVSkill
    {
        public int CVId;
        public int SkillId;

        /// Config 1:n relationship Skill:CV
        public CV? RefCV;

        /// Config 1:n relationship Skill:CVSkill
        public Skill? RefSkill;
    }
}
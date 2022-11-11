namespace SimpleCV.Data.Entities
{
    public class CV
    {
        public int CVId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CVUrl { get; set; }

        /// Config 1:1 relationship CV:Info 
        public Info? RefInfo { get; set; }

        /// Config n:1 relationship CV:CVActivity
        public virtual ICollection<CVActivity>? CVActivities { get; set; }
        
        /// Config n:1 relationship Skill:CVSkill
        public virtual ICollection<CVSkill>? CVSkills { get; set; }
    }
}
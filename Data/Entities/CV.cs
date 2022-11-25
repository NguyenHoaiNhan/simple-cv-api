namespace SimpleCV.Data.Entities
{
    public class CV
    {
        public int CVId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CVUrl { get; set; }
        public int? AccountId { get; set; }

        /// Config 1:1 relationship CV:Info 
        public virtual Info? RefInfo { get; set; }

        /// Config 1:n relationship CV:Activity
        public virtual ICollection<Activity>? Activities { get; set; }

        /// Config n:1 relationship Skill:CVSkill
        public virtual ICollection<CVSkill>? CVSkills { get; set; }

        /// Config n:1 relationship CV:Account
        public virtual Account? RefAccount { get; set; }
    }
}
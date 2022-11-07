namespace SimpleCV.Data.Entities
{
    public class CV
    {
        public int CVId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CVUrl { get; set; }
        public virtual Info? RefInfo { get; set; }
        public virtual ICollection<Skill>? Skills { get; set; }
        public virtual ICollection<Activity>? Activities { get; set; }
    }
}
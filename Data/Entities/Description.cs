namespace SimpleCV.Data.Entities
{
    public class Description
    {
        public int ActivityId { get; set; }
        public bool? IsBold { get; set; }
        public bool? IsItalic { get; set; }
        public bool? IsUnderline { get; set; }
        public int? BulletType { get; set; }
        public int? Alignment { get; set; }
        public virtual Activity? RefActivity { get; set; }
    }
}
namespace SimpleCV.Data.Entities
{
    public class Description
    {
        public int ActivityId { get; set; }
        public string? DescriptionPara {get;set;} 
        public bool? IsBold { get; set; }
        public bool? IsItalic { get; set; }
        public bool? IsUnderline { get; set; }
        public int? BulletType { get; set; }
        public int? Alignment { get; set; }

        /// Config 1:1 relationship Activity:Description
        public virtual Activity? RefActivity { get; set; }
    }
}
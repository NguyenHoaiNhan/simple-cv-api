namespace SimpleCV.Data.Models
{
    public class TextForm
    {
        public int ActivityId { get; set; }
        public string? DescriptionPara { get; set; }
        public bool? IsBold { get; set; } = false;
        public bool? IsItalic { get; set; } = false;
        public bool? IsUnderline { get; set; } = false;
        public int BulletType { get; set; } = 0;
        public int TextBullet { get; set; } = 0;
    }
}
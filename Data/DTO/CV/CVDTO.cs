namespace SimpleCV.Data.DTO.CV
{
    public class CVDTO
    {
        public int CVid { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public string? CVUrl { get; set; }
    }
}
namespace SimpleCV.Data.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string? AccountPwd { get; set; }
        public string? AccountName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        /// Config 1:n relationship Account:CV
        public virtual ICollection<CV>? CVs { get; set; }
    }
}
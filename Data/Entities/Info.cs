namespace SimpleCV.Data.Entities
{
    public class Info
    {
        public int CVId { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public string? Email { get; set; }
        public string? HeadLine { get; set; }
        public string? PhoneNum { get; set; }
        public string? Address { get; set; }
        public string? PostCode { get; set; }
        public string? City { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? DriverLicense { get; set; }
        public int? Gender { get; set; }
        public int? CountryId { get; set; }
        public int? CivilStatusId { get; set; }
        public string? GithubLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? Avatar { get; set; }
        public string? CivilStatus { get; set; }
        public string? Country { get; set; }
        public string? InfoTitle { get; set; }

        /// Config 1:1 relationship CV:Info 
        public int? FKCVId { get; set; }
        public CV? RefCV { get; set; }
    }
}
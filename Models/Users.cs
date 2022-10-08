using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCV.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int userId {get; set;}
        [Column("first_name")]
        public string? FirstName {get; set;}

        [Column("family_name")]
        public string? FamilyName {get; set;}

        [Column("mid_name")]
        public string? MidName {get; set;}

        [Column("phone")]
        public string? Phone {get; set;}
        
        [Column("address")]
        public string? Address {get; set;}
        
    }
}
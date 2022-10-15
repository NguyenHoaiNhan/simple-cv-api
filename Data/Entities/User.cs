using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCV.Data.Entities
{
    public class User
    {
        // public User(int id, string firstName, string familyName, string midName, string phone, string address)
        // {
        //     Id = id;
        //     FirstName = firstName;
        //     FamilyName = familyName;
        //     MidName = midName;
        //     Phone = phone;
        //     Address = address;
        // }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public string MidName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
using EmployeeDirectoryProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Address1 { get; set; }
        public string LanguagesSpoken { get; set; }
        public int ContactNumber { get; set; }
        public string HobbiesAndInterest { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public DateTime? HireDate { get; set; }
        public string Department { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PasswordAttemptFail { get; set; }
        public UserType UserType { get; set; }
    }
}

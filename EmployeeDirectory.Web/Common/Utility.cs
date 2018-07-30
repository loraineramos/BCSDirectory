using EmployeeDirectory.Web.Models;
using EmployeeDirectoryProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Common
{
    public class Utility
    {
        public static UserModel UserMapper(UserViewModel userViewModel)
        {
            return new UserModel()
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Age = userViewModel.Age,
                Address1 = userViewModel.Address1,
                Birthday = userViewModel.Birthday,
                CivilStatus = userViewModel.CivilStatus,
                ContactNumber = userViewModel.ContactNumber,
                Country = userViewModel.Country,
                State = userViewModel.State,
                Department = userViewModel.Department,
                Gender = userViewModel.Gender,
                HireDate = userViewModel.HireDate,
                HobbiesAndInterest = userViewModel.HobbiesAndInterest,
                LanguagesSpoken = userViewModel.LanguagesSpoken,
                UserName = userViewModel.UserName,
                Password = userViewModel.Password,
                PasswordAttemptFail = userViewModel.PasswordAttemptFail,
                UserType = userViewModel.UserType
            };
        }
    }
}

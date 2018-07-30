using EmployeeDirectoryProcessor.Data;
using EmployeeDirectoryProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryProcessor.Data.Entities;
using EmployeeDirectory.Api.Interfaces;
using EmployeeDirectory.Api.Common;

namespace EmployeeDirectoryServices.ProcessorManager
{
    public class UserManager : IUserManager
    {
        private readonly DirectoryContext _context;
        public UserManager(DirectoryContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUser(UserModel userModel)
        {
            if (userModel == null)
                throw new ArgumentNullException();
            try
            {
                User userEntity = new User()
                {
                    Id = userModel.Id,
                    Address1 = userModel.Address1,
                    Age = userModel.Age,
                    Birthday = userModel.Birthday,
                    CivilStatus = userModel.CivilStatus,
                    ContactNumber = userModel.ContactNumber,
                    Country = userModel.Country,
                    Department = userModel.Department,
                    FirstName = userModel.FirstName,
                    Gender = userModel.Gender,
                    HireDate = userModel.HireDate,
                    HobbiesAndInterest = userModel.HobbiesAndInterest,
                    LanguagesSpoken = userModel.LanguagesSpoken,
                    LastName = userModel.LastName,
                    Password = userModel.Password,
                    PasswordAttemptFail = userModel.PasswordAttemptFail,
                    State = userModel.State,
                    UserName = userModel.UserName,
                    UserType = userModel.UserType.ToString()
                };
                _context.Users.Add(userEntity);
                _context.SaveChanges();
                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteUser(string userName)
        {
            try
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    var user = _context.Users.FirstOrDefault(f => f.UserName == userName);
                    if (user == null)
                        return false;
                    _context.Remove(user);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var userList = _context.Users.ToList();
            List <UserModel> userListModel = null;
            if (userList.Count > 0 && userList != null)
            {
                foreach (var user in userList)
                {
                    UserModel userModel = new UserModel()
                    {
                        Id = user.Id,
                        Address1 = user.Address1,
                        Age = user.Age,
                        Birthday = user.Birthday,
                        CivilStatus = user.CivilStatus,
                        ContactNumber = user.ContactNumber,
                        Country = user.Country,
                        Department = user.Department,
                        FirstName = user.FirstName,
                        Gender = user.Gender,
                        HireDate = user.HireDate,
                        HobbiesAndInterest = user.HobbiesAndInterest,
                        LanguagesSpoken = user.LanguagesSpoken,
                        LastName = user.LastName,
                        Password = user.Password,
                        PasswordAttemptFail = user.PasswordAttemptFail,
                        State = user.State,
                        UserName = user.UserName,
                        UserType = UserManagerHelper.GetUserType(user.UserType)
                    };
                     userListModel.Add(userModel);
                }
            }
            return userListModel;
        }

        public async Task<UserModel> GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null; //to do: Create custom exceptions
            }
            try
            {
                UserModel userModel = null;
                var user = _context.Users.Where(w => w.UserName == userName).FirstOrDefault();
                if (user != null)
                {
                    userModel = new UserModel()
                    {
                        Id = user.Id,
                        Address1 = user.Address1,
                        Age = user.Age,
                        Birthday = user.Birthday,
                        CivilStatus = user.CivilStatus,
                        ContactNumber = user.ContactNumber,
                        Country = user.Country,
                        Department = user.Department,
                        FirstName = user.FirstName,
                        Gender = user.Gender,
                        HireDate = user.HireDate,
                        HobbiesAndInterest = user.HobbiesAndInterest,
                        LanguagesSpoken = user.LanguagesSpoken,
                        LastName = user.LastName,
                        Password = user.Password,
                        PasswordAttemptFail = user.PasswordAttemptFail,
                        State = user.State,
                        UserName = user.UserName,
                        UserType = UserManagerHelper.GetUserType(user.UserType)
                    };

                }
                return userModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserModel>> GetUserByUserType(UserType userType)
        {
            var users = _context.Users.Where(w => w.UserType == userType.ToString()).ToList();
            List<UserModel> userListModel = null;
            foreach (var user in users)
            {
                UserModel userModel = new UserModel()
                {
                    Id = user.Id,
                    Address1 = user.Address1,
                    Age = user.Age,
                    Birthday = user.Birthday,
                    CivilStatus = user.CivilStatus,
                    ContactNumber = user.ContactNumber,
                    Country = user.Country,
                    Department = user.Department,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    HireDate = user.HireDate,
                    HobbiesAndInterest = user.HobbiesAndInterest,
                    LanguagesSpoken = user.LanguagesSpoken,
                    LastName = user.LastName,
                    Password = user.Password,
                    PasswordAttemptFail = user.PasswordAttemptFail,
                    State = user.State,
                    UserName = user.UserName,
                    UserType = UserManagerHelper.GetUserType(user.UserType)
                };
                userListModel.Add(userModel);
            }
            return userListModel;
        }

        public async Task<bool> UpdateUser(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException();//to change to custom exception
            }
            try
            {
                var user = _context.Users.Where(w => w.UserName == userModel.UserName).FirstOrDefault();
                if (user == null)
                    return false;
                user.Id = userModel.Id;
                user.Address1 = userModel.Address1;
                user.Age = userModel.Age;
                user.Birthday = userModel.Birthday;
                user.CivilStatus = userModel.CivilStatus;
                user.ContactNumber = userModel.ContactNumber;
                user.Country = userModel.Country;
                user.Department = userModel.Department;
                user.FirstName = userModel.FirstName;
                user.Gender = userModel.Gender;
                user.HireDate = userModel.HireDate;
                user.HobbiesAndInterest = userModel.HobbiesAndInterest;
                user.LanguagesSpoken = userModel.LanguagesSpoken;
                user.LastName = userModel.LastName;
                user.Password = userModel.Password;
                user.PasswordAttemptFail = userModel.PasswordAttemptFail;
                user.State = userModel.State;
                user.UserType = userModel.UserType.ToString();
                user.UserName = userModel.UserName;
                _context.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

using EmployeeDirectoryProcessor.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectoryProcessor.Interfaces
{
    public interface IUserManager
    {
        void CreateUser(User user);
        User GetUser(string userName);
        List<User> GetUserByUserType(UserType userType);
        List<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(string userName);

    }
}

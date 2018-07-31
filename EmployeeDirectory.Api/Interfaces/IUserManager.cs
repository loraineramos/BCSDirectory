using EmployeeDirectoryProcessor.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Api.Interfaces
{
    public interface IUserManager
    {
        Task<bool> CreateUser(UserModel user);
        Task<UserModel> GetUser(string userName);
        Task<IEnumerable<UserModel>> GetUserByUserType(UserType userType);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<bool> UpdateUser(UserModel user);
        Task<bool> DeleteUser(string userName);

    }
}

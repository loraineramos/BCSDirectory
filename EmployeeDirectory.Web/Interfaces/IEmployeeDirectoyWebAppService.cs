using EmployeeDirectoryProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Interfaces
{
    public interface IEmployeeDirectoyWebAppService
    {
        bool CreateUser(UserModel user);
        Task<UserModel> GetUser(string userName);
        Task<IEnumerable<UserModel>> GetUserByUserType(UserType userType);
        Task<IEnumerable<UserModel>> GetAllUsers();
        bool UpdateUser(UserModel user);
        bool DeleteUser(string userName);
        bool ValidateLogin(string userName, string password);
    }
}

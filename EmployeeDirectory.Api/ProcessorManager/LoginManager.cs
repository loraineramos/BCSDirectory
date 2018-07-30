using EmployeeDirectory.Api.Interfaces;
using EmployeeDirectoryProcessor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Api.ProcessorManager
{
    public class LoginManager : ILoginManager
    {
        private readonly DirectoryContext _context;
        public LoginManager(DirectoryContext context)
        {
            _context = context;
        }
        public bool ValidateLogin(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new Exception("User Name or Password cannot be empty");
            var user = _context.Users.Where(a => a.UserName == userName && a.Password == password).FirstOrDefault();
            if (user != null)
                return true;
            else
                return false;
        }
    }
}

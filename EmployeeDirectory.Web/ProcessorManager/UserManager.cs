using EmployeeDirectoryProcessor.Data;
using EmployeeDirectoryProcessor.Interfaces;
using EmployeeDirectoryProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeDirectoryProcessor.ProcessorManager
{
    public class UserManager : IUserManager
    {
        private readonly DirectoryContext _context;
        public UserManager(DirectoryContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            _context.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var user = _context.Users.FirstOrDefault(f => f.UserName == userName);
                _context.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _context.Users.ToList();

        }

        public User GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserByUserType(UserType userType)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

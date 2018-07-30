using EmployeeDirectoryProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Api.Common
{
    public static class UserManagerHelper
    {
        public static UserType GetUserType(string userType)
        {
            if (string.IsNullOrEmpty(userType))
                throw new ArgumentNullException("User Type cannot be empty");

            switch (userType.ToLower())
            {
                case "editor":
                    return UserType.Editor;
                case "viewer":
                    return UserType.Viewer;
                default:
                    return UserType.Employee;
            }
        }
    }
}

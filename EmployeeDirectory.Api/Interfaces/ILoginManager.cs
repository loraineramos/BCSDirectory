using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Api.Interfaces
{
    public interface ILoginManager
    {
        bool ValidateLogin(string userName, string password);
    }
}

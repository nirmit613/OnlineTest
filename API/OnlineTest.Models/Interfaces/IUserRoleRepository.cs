using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface IUserRoleRepository
    {
        List<string> GetRoles(int userId);
        bool AddRole(UserRole role);
    }
}

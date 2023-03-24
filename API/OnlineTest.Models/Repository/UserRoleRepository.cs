using OnlineTest.Data;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class UserRoleRepository: IUserRoleRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public UserRoleRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Enum
        private enum RoleMap
        {
            Admin = 1,
            User = 2
        }
        #endregion
        #region Methods
        public List<string> GetRoles(int userId)
        {
            var result = _context.UserRoles.Where(u => u.UserId == userId).ToList().OrderBy(i=>i.RoleId);
            List<string> roles = new List<string>();
            foreach (var row in result)
            {
                roles.Add(((RoleMap)row.RoleId).ToString());
            }
            return roles;
        }

        public bool AddRole(UserRole role)
        {
            _context.Add(role);
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}

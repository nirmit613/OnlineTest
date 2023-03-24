using OnlineTest.Models.Interfaces;
using OnlineTest.Services.Interface;

namespace OnlineTest.Services.Services
{
    public class UserRoleService : IUserRoleService
    {
        #region Fields
        private readonly IUserRoleRepository _userRoleRepository;
        #endregion
        #region Constructors
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        #endregion
        #region Methods
        public List<string> GetRoles(int userId)
        {
            return _userRoleRepository.GetRoles(userId);
        }
        #endregion

    }
}

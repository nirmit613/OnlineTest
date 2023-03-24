using OnlineTest.Data;
using OnlineTest.Model.Interfaces;
using OnlineTest.Models;

namespace OnlineTest.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructors
        public UserRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Where(u => u.IsActive == true).ToList();
        }
        public IEnumerable<User> GetUserPagination(int PageNo, int RowsPerPage)
        {
            return _context.Users.Where(u => u.IsActive == true).Skip((PageNo - 1) * RowsPerPage).Take(RowsPerPage).ToList();
        }
        public User GetUserbyId(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id && u.IsActive == true);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.IsActive == true);
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            if (_context.SaveChanges() > 0)
                return user.Id;
            else
                return 0;
        }
        public bool UpdateUser(User user)
        {
            _context.Entry(user).Property("MobileNumber").IsModified = true;
            _context.Entry(user).Property("Email").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        public bool DeleteUser(User user)
        {
            _context.Entry(user).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        #endregion
    }
}
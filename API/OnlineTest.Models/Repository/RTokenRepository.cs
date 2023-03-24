using OnlineTest.Data;
using OnlineTest.Model;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class RTokenRepository : IRTokenRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public RTokenRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public RToken GetRefreshToken(int id, string refreshToken)
        {
            return _context.RTokens.FirstOrDefault(x => x.UserId == id && x.RefreshToken == refreshToken);
        }

        public bool AddRefreshToken(RToken token)
        {
            _context.RTokens.Add(token);
            return _context.SaveChanges() > 0;
        }

        public bool ExpireRefreshToken(RToken token)
        {
            _context.Entry(token).Property("IsStop").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
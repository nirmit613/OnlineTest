using OnlineTest.Data;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class TestLinkRepository : ITestLinkRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public TestLinkRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public TestLink GetTestLink(Guid token)
        {
            return _context.TestLinks.FirstOrDefault(t => t.Token == token && t.ExpireOn > DateTime.UtcNow);
        }

        public int AddTestLink(TestLink testLink)
        {
            _context.Add(testLink);
            if (_context.SaveChanges() > 0)
                return testLink.Id;
            else
                return 0;
        }

        public bool IsTestLinkExists(int testId, int userId)
        {
            var result = _context.TestLinks.FirstOrDefault(t => t.TestId == testId && t.UserId == userId && t.ExpireOn > DateTime.UtcNow);
            if (result != null)
                return true;
            else
                return false;
        }

        public bool UpdateTestLink(TestLink testLink)
        {
            _context.Entry(testLink).Property("AccessOn").IsModified = true;
            //_context.Entry(testLink).Property("Attempts").IsModified = true;
            //_context.Entry(testLink).Property("SubmitOn").IsModified = true;
            //_context.Entry(testLink).Property("").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}

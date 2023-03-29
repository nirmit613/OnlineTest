using OnlineTest.Data;
using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Repository
{
    public class MailOutBoundRepository : IMailOutBoundRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public MailOutBoundRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public int AddMailOutBound(MailOutBound mailOutBound)
        {
            _context.Add(mailOutBound);
            if(_context.SaveChanges()>0)
                return mailOutBound.Id;
            else
                return 0;
        }
        #endregion
    }
}

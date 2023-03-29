using OnlineTest.Data;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class AnswerSheetRepository : IAnswerSheetRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public AnswerSheetRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public bool AddAnswerSheet(List<AnswerSheet> answerSheets)
        {
            _context.AddRange(answerSheets);
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}

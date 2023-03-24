using OnlineTest.Data;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class QuestionAnswerMapRepository: IQuestionAnswerMapRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public QuestionAnswerMapRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public int AddMap(QuestionAnswerMap map)
        {
            _context.Add(map);
            if (_context.SaveChanges() > 0)
                return map.Id;
            else
                return 0;
        }
        #endregion
    }
}

using OnlineTest.Data;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion
        #region Constructors
        public QuestionRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods

        public IEnumerable<Question> GetQuestionsByTestId(int testId)
        {
            return _context.Questions.Where(q => q.TestId == testId && q.IsActive == true).OrderBy(q => q.SortOrder).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == id && q.IsActive == true);

        }
        public Question IsQuestionExists(Question question)
        {
            var result = _context.Questions.FirstOrDefault(q => q.TestId == question.TestId && q.Que == question.Que && q.IsActive == true);
            return result;
        }

        public int AddQuestion(Question question)
        {
            _context.Add(question);
            if (_context.SaveChanges() > 0)
                return question.Id;
            else
                return 0;
        }
        public bool UpdateQuestion(Question question)
        {
            _context.Entry(question).Property("QuestionName").IsModified = true;
            _context.Entry(question).Property("Que").IsModified = true;
            _context.Entry(question).Property("Weightage").IsModified = true;
            _context.Entry(question).Property("SortOrder").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        public bool DeleteQuestion(Question question)
        {
            _context.Entry(question).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        #endregion
    }
}


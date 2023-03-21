using Microsoft.EntityFrameworkCore;
using OnlineTest.Data;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly OnlineTestContext _context;
        public QuestionRepository(OnlineTestContext context)
        {
            _context = context;
        }
        public IEnumerable<Question> GetQuestionsByTestId(int testId)
        {
            return _context.Questions.Where(q => q.TestId == testId && q.IsActive == true).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == id && q.IsActive == true);

        }
        public bool IsQuestionExists(int testId, string que)
        {
            var result = _context.Questions.FirstOrDefault(q => q.TestId == testId && q.Que == que && q.IsActive == true);
            if (result != null)
                return true;
            else
                return false;
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
    }
}


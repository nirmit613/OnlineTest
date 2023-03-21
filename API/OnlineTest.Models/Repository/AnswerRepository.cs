using Microsoft.EntityFrameworkCore;
using OnlineTest.Data;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class AnswerRepository:IAnswerRepository
    {
        private readonly OnlineTestContext _context;
        public AnswerRepository(OnlineTestContext context)
        {
            _context = context;
        }
        public IEnumerable<Answer> GetAnswers()
        {
            return _context.Answers.Where(a => a.IsActive == true).ToList();
        }
        public IEnumerable<Answer> GetAnswersByQuestionId(int questionId)
        {
            return (from qam in _context.QuestionAnswerMapping
                    join a in _context.Answers
                    on qam.AnswerId equals a.Id
                    where qam.QuestionId == questionId
                    select new Answer
                    {
                        Id = a.Id,
                        Ans = a.Ans,
                        IsActive = a.IsActive,
                        CreatedBy = a.CreatedBy,
                        CreatedOn = a.CreatedOn
                    }).ToList();
        }

        public Answer GetAnswerById(int id)
        {
            return _context.Answers.FirstOrDefault(a => a.Id == id && a.IsActive == true);
        }
        public bool IsAnswerExists(int testId, int questionId, string ans)
        {
            var result = (from qam in _context.QuestionAnswerMapping
                          join a in _context.Answers
                          on qam.AnswerId equals a.Id
                          where qam.TestId == testId && qam.QuestionId == questionId && a.Ans == ans
                          select new
                          {
                              Id = qam.Id
                          }).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }
        public int AddAnswer(Answer answer)
        {
            _context.Add(answer);
            if (_context.SaveChanges() > 0)
                return answer.Id;
            else
                return 0;
        }

        public bool UpdateAnswer(Answer answer)
        {
            _context.Entry(answer).Property("Ans").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        public bool DeleteAnswer(Answer answer)
        {
            _context.Entry(answer).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
    }
}

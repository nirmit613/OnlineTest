using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestionsByTestId(int testId);
        Question GetQuestionById(int id);
        bool IsQuestionExists(int testId, string que);
        int AddQuestion(Question question);  
        bool UpdateQuestion(Question question);
        bool DeleteQuestion(Question question);
    }
}
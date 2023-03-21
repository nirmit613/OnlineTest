using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswers();
        IEnumerable<Answer> GetAnswersByQuestionId(int questionId);
        bool IsAnswerExists(int testId, int questionId, string ans);
        Answer GetAnswerById(int id);
        int AddAnswer(Answer answer);
        bool UpdateAnswer(Answer answer);
        bool DeleteAnswer(Answer answer);  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface IQuestionAnswerMapRepository
    {
        int AddMap(QuestionAnswerMap map);
    }
}

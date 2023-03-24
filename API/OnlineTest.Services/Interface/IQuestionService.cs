using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{
    public interface IQuestionService
    {
        ResponseDTO GetQuestionsByTestId(int testId);
        ResponseDTO GetQuestionById(int id);
        ResponseDTO AddQuestion(int userId,AddQuestionDTO question);
        ResponseDTO UpdateQuestion(UpdateQuestionDTO question);
        ResponseDTO DeleteQuestion(int id);
    }
}

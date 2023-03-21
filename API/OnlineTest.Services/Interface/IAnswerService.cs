using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{
    public interface IAnswerService
    {
        ResponseDTO GetAnswers();
        ResponseDTO GetAnswerById(int id);
        ResponseDTO AddAnswer(AddAnswerDTO answer);
        ResponseDTO UpdateAnswer(UpdateAnswerDTO answer);
        ResponseDTO DeleteAnswer(int id);
    }
}

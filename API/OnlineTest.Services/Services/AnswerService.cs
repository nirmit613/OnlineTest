using AutoMapper;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;

namespace OnlineTest.Services.Services
{
    public class AnswerService : IAnswerService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionAnswerMapRepository _qaMapRepository;
        #endregion
        #region Constructors
        public AnswerService(IMapper mapper, IAnswerRepository answerRepository, ITestRepository testRepository, IQuestionRepository questionRepository, IQuestionAnswerMapRepository qaMapRepository)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _qaMapRepository = qaMapRepository;
        }
        #endregion
        #region Methods
        public ResponseDTO GetAnswersByQuestionId(int questionId)
        {
            var response = new ResponseDTO();
            try
            {
                var questionById = _questionRepository.GetQuestionById(questionId);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                var data = _mapper.Map<List<GetAnswerDTO>>(_answerRepository.GetAnswersByQuestionId(questionId).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO GetAnswerById(int id)
        {

            var response = new ResponseDTO();
            try
            {
                var answerById = _answerRepository.GetAnswerById(id);
                if (answerById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Answer not found";
                    return response;
                }
                var data = _mapper.Map<GetAnswerDTO>(answerById);
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO AddAnswer(int userId, AddAnswerDTO answer)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(answer.TestId);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test not found";
                    return response;
                }
                var questionById = _questionRepository.GetQuestionById(answer.QuestionId);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                var answerExists = _answerRepository.IsAnswerExists(answer.TestId, answer.QuestionId, answer.Ans);
                if (answerExists != null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Answer already exists";
                    return response;
                }
                answer.IsActive = true;
                answer.CreatedBy = userId;
                answer.CreatedOn = DateTime.UtcNow;
                var answerId = _answerRepository.AddAnswer(_mapper.Map<Answer>(answer));
                if (answerId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add answer";
                    return response;
                }
                var map = new QuestionAnswerMap
                {
                    TestId = answer.TestId,
                    QuestionId = answer.QuestionId,
                    AnswerId = answerId,
                    IsActive = true,
                    CreatedBy = answer.CreatedBy,
                    CreatedOn = answer.CreatedOn,
                };
                _qaMapRepository.AddMap(map);
                response.Status = 201;
                response.Message = "Created";
                response.Data = answerId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;

        }
        public ResponseDTO UpdateAnswer(UpdateAnswerDTO answer)
        {
            var response = new ResponseDTO();
            try
            {
                var answerById = _answerRepository.GetAnswerById(answer.Id);
                if (answerById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Answer not found";
                    return response;
                }
                var answerExists = _answerRepository.IsAnswerExists(answer.TestId, answer.QuestionId, answer.Ans);
                if (answerExists != null && answer.Id != answerExists.Id)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Answer already exists";
                    return response;
                }
                var updateFlag = _answerRepository.UpdateAnswer(_mapper.Map<Answer>(answer));
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update answer";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;

        }
        public ResponseDTO DeleteAnswer(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var answerById = _answerRepository.GetAnswerById(id);
                if (answerById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Answer not found";
                    return response;
                }
                answerById.IsActive = false;
                var deleteFlag = _answerRepository.DeleteAnswer(_mapper.Map<Answer>(answerById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete answer";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }


        #endregion

    }
}

using AutoMapper;
using OnlineTest.Model.Interfaces;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;

namespace OnlineTest.Services.Services
{
    public class TestService : ITestService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITestLinkRepository _testLinkRepository;
        #endregion

        #region Constructors
        public TestService(IMapper mapper, ITestRepository testRepository, ITechnologyRepository technologyRepository, IQuestionRepository questionRepository,IAnswerRepository answerRepository,ITestLinkRepository testLinkRepository, IUserRepository userRepository)
        {
            _testRepository = testRepository;
            _technologyRepository = technologyRepository;
            _questionRepository = questionRepository;  
            _answerRepository = answerRepository;
            _userRepository = userRepository;
            _testLinkRepository = testLinkRepository;
            _mapper = mapper;
        }
        #endregion
        #region Methods

        public ResponseDTO GetTests()
        {
            var response = new ResponseDTO();
            try
            {
                var test = _mapper.Map<List<GetTestDTO>>(_testRepository.GetTests().ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = test;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTestById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var test = _testRepository.GetTestById(id);
                if (test == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Tests not found";
                    return response;
                }
                var data = _mapper.Map<GetTestDTO>(test);
                var questionsList = _mapper.Map<List<GetQuestionDTO>>(_questionRepository.GetQuestionsByTestId(test.Id).ToList());
                foreach (var question in questionsList)
                {
                    var answersList = _mapper.Map<List<GetAnswerDTO>>(_answerRepository.GetAnswersByQuestionId(question.Id).ToList());
                    question.Answers = answersList;
                }
                data.Questions = questionsList;
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

        public ResponseDTO GetTestsPagination(int PageNo, int RowsPerPage)
        {

            var response = new ResponseDTO();
            try
            {
                var test = _mapper.Map<List<GetTestDTO>>(_testRepository.GetTestsPaginatation(PageNo, RowsPerPage)).ToList();
                response.Status = 200;
                response.Message = "Ok";
                response.Data = test;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO GetTestsByTechnologyId(int technologyId)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologybyId(technologyId);
                if (technologyById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }
                var data = _mapper.Map<List<GetTestDTO>>(_testRepository.GetTestsByTechnologyId(technologyId).ToList());
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

        public ResponseDTO AddTest(int userId, AddTestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologybyId(test.TechnologyId);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Technology does not exist";
                    return response;
                }
                var testExist = _testRepository.IsTestExists(_mapper.Map<Test>(test));
                if (testExist!=null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test already exists";
                    return response;
                }
                test.IsActive = true;
                test.CreatedBy = userId;
                test.CreatedOn = DateTime.UtcNow;
                var testId = _testRepository.AddTest(_mapper.Map<Test>(test));
                if (testId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add test";
                    return response;
                }
                response.Status = 201;
                response.Message = "Created";
                response.Data = testId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO UpdateTest(UpdateTestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(test.Id);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test does not exist";
                    return response;
                }
                var testExist = _testRepository.IsTestExists(_mapper.Map<Test>(test));
                if (testExist != null && test.Id != testExist.Id)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Test already exists";
                    return response;
                }
                
                var updateFlag = _testRepository.UpdateTest(_mapper.Map<Test>(test));
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update test";
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
        public ResponseDTO DeleteTest(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(id);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test does not exist";
                    return response;
                }
                testById.IsActive = false;
                var deleteFlag = _testRepository.DeleteTest(_mapper.Map<Test>(testById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete test";
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
        public ResponseDTO AddTestLink(int adminId, int testId, string email)
        {
            var response = new ResponseDTO();
            try
            {
                // check if user exists
                var userByEmail = _userRepository.GetUserByEmail(email);
                if (userByEmail == null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "User does not exist";
                    return response;
                }

                // check if test exists
                var testById = _testRepository.GetTestById(testId);
                if (testById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test does not exist";
                    return response;
                }

                // check if link has already been created and not expired
                var existFlag = _testLinkRepository.IsTestLinkExists(testId, userByEmail.Id);
                if (existFlag)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test link already exists";
                    return response;
                }

                var testLink = new AddTLinkDTO
                {
                    TestId = testId,
                    UserId = userByEmail.Id,
                    Token = Guid.NewGuid(),
                    Attempts = 0,
                    ExpireOn = DateTime.UtcNow.AddDays(7),
                    IsActive = true,
                    CreatedBy = adminId,
                    CreatedOn = DateTime.UtcNow,
                };

                var testLinkId = _testLinkRepository.AddTestLink(_mapper.Map<TestLink>(testLink));
                if (testLinkId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add test link";
                    return response;
                }
                response.Status = 201;
                response.Message = "Created";
                response.Data = testLinkId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO GetTestByLink(string token, string email)
        {
            var response = new ResponseDTO();
            try
            {
                var testLink = _testLinkRepository.GetTestLink(Guid.Parse(token));
                if (testLink == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test link does not exist or expired";
                    return response;
                }
                var userById = _userRepository.GetUserbyId(testLink.UserId);
                if (email.ToLower() != userById.Email.ToLower())
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Email is incorrect";
                    return response;
                }
                response = GetTestById(testLink.TestId);
                if (response.Status == 200)
                {
                    testLink.AccessOn = DateTime.UtcNow;
                    _testLinkRepository.UpdateTestLink(testLink);
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using System.Security.Claims;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswerController : ControllerBase
    {
        #region Fields
        private readonly IAnswerService _answerService;
        #endregion
        #region Constructors
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        #endregion
        #region Methods
        [HttpGet]
        public IActionResult GetAnswersByQuestionId(int questionId)
        {
            return Ok(_answerService.GetAnswersByQuestionId(questionId));
        }
        [HttpPost]
        public IActionResult AddQuestion(AddAnswerDTO answer)
        {
            return Ok(_answerService.AddAnswer(Convert.ToInt32(User.FindFirstValue("Id")), answer));
        }

        [HttpPut]
        public IActionResult UpdateAnswer(UpdateAnswerDTO answer)
        {
            return Ok(_answerService.UpdateAnswer(answer));
        }
        #endregion
    }
}

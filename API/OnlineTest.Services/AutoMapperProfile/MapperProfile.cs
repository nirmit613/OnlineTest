using AutoMapper;
using OnlineTest.Models;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.AutoMapperProfile
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<User, GetUserDTO>();
            CreateMap<AddUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            #endregion

            #region Technology
            CreateMap<Technology, GetTechnologyDTO>();
            CreateMap<AddTechnologyDTO, Technology>();
            CreateMap<UpdateTechnologyDTO, Technology>();
            #endregion

            #region Test
            CreateMap<Test, GetTestDTO>();
            CreateMap<AddTestDTO, Test>();
            CreateMap<UpdateTechnologyDTO, Test>();
            #endregion

            #region Question
            CreateMap<Question, GetQuestionDTO>();
            CreateMap<AddQuestionDTO, Question>();
            CreateMap<UpdateQuestionDTO, Question>();
            #endregion
            #region Answer
            CreateMap<Answer, GetAnswerDTO>();
            CreateMap<AddAnswerDTO, Answer>();
            CreateMap<UpdateAnswerDTO, Answer>();
            #endregion
        }
    }
}

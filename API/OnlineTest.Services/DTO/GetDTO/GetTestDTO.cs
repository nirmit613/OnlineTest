using OnlineTest.Services.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.GetDTO
{
    public class GetTestDTO
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public DateTime? ExpireOn { get; set; }
        public int TechnologyId { get; set; }
        public List<GetQuestionDTO>? Questions { get; set; }
    }
}
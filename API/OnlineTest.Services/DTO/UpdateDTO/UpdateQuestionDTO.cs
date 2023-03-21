using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.UpdateDTO
{
    public class UpdateQuestionDTO
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string Que { get; set; }
        public int Weightage { get; set; }
        public int SortOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddAnswerDTO
    {
        [Required(ErrorMessage = "Answer is required")]
        public string Ans { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
    }
}

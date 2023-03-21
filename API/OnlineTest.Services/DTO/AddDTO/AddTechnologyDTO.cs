using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddTechnologyDTO
    {
        [Required(ErrorMessage = "Technology name is required. Please Enter Name")]
        [MaxLength(50, ErrorMessage = "Technology name can not be longer than 50 characters.")]
        public string TechName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

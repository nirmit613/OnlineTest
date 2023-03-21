using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddTestDTO
    {
        [Required(ErrorMessage = "Test name is required")]
        public string TestName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime? ExpireOn { get; set; }
        [Required(ErrorMessage = "Technology is required")]
        public int TechnologyId { get; set; } 
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }     
        public DateTime CreatedOn { get; set; }
    }
}
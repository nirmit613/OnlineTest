using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddUserDTO
    {

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name can not be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [MaxLength(64, ErrorMessage = "Email address can not be longer than 64 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must contain 10 digits only")]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password should be {2} to {1} characters long")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
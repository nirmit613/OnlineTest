using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name can not be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [MaxLength(64, ErrorMessage = "Email address can not be longer than 64 characters")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must contain 10 digits only")]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(256)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}

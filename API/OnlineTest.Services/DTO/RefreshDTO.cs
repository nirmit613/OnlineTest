using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Services.DTO
{
    public class RefreshDTO
    {
        [Required(ErrorMessage = "User id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Refresh token is required")]
        public string RefreshToken { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Services.DTO
{
    public class RTokenDTO
    {
        [MaxLength(32)]
        public string RefreshToken { get; set; }
        public bool IsStop { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
    }
}
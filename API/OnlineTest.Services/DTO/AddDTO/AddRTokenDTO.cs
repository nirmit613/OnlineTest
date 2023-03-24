namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddRTokenDTO
    {
        public string RefreshToken { get; set; }
        public bool IsStop { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
    }
}
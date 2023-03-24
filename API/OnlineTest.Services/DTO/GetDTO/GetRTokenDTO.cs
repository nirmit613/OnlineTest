namespace OnlineTest.Services.DTO.GetDTO
{
    public class GetRTokenDTO
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public bool IsStop { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
    }
}
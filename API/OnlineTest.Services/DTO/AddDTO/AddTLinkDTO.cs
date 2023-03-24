namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddTLinkDTO
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public Guid Token { get; set; }
        public int Attempts { get; set; }
        public DateTime ExpireOn { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

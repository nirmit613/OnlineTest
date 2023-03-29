using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class AnswerSheet
    {
        [Key]
        public int Id { get; set; }
        public Guid Token { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId{ get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
    }
}

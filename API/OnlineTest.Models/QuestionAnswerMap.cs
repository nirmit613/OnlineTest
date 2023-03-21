using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class QuestionAnswerMap
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Test")]
        public int TestId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}

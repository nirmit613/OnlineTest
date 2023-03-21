using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string Que { get; set; }
        public int Type { get; set; }
        public int Weightage { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }

    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Ans { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime CreatedOn { get; set; }
    }
}

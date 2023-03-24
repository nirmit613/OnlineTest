using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class TestLink
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Test")]
        public int TestId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Token { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? AccessOn { get; set;}
        public int Attempts { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SubmitOn { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ExpireOn { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public Test Test { get; set; }
        public User User { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineTest.Models
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }
        public string TechName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }  

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int? ModifiedBy { get; set; }   

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

    }
}
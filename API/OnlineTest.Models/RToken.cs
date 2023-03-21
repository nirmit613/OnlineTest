using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Model
{
    public class RToken
    {
        [Key]       
        public int Id { get; set; }
        [Column("Refresh_Token", TypeName = "varchar(150)")]
        public string RefreshToken { get; set; }
        [Column("Is_Stop")]
        public int IsStop { get; set; }
        [Column("Created_Date", TypeName = "datetime")]

        public DateTime CreatedDate { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserNavigation { get; set; }
    }
}

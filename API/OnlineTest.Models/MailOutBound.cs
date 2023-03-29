using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public class MailOutBound
    {
        [Key]
        public int Id { get; set; }
        public string To { get; set; }
        public string Body { get; set; }

        [ForeignKey("TestLink")]
        public int TestLinkId { get; set; }
        public TestLink TestLink { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
    }
}

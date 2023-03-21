﻿using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}

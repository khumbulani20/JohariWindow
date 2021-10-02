using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class Friend
    {
        [Key]
        public int FreindID { get; set; }
        [Required]
        public string Relationship { get; set; }

        [Required]
        public string HowLong { get; set; }
    }
}

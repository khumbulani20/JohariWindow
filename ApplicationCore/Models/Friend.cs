using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class Friend
    {
        [Key]
        public int FriendID { get; set; }
        [Required]
        public string Relationship { get; set; }

        [Required]
        public string HowLong { get; set; }

        public virtual string ASPNETUserID { get; set; }
        [NotMapped]
        [ForeignKey("ASPNETUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

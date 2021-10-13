using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class Client
    {
      [Key]
        [Display(Name ="id")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }

        public virtual string ASPNETUserID { get; set; }
        [NotMapped]
        [ForeignKey("ASPNETUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        //public static string GetApplicationUserId(string firstName, string lastName, DateTime dob)
        //{

        //}

    }
}

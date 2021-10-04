using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

     
        public DateTime DOB { get; set; }
 
        public string Gender { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
       

    }

}

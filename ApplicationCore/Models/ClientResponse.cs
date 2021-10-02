using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class ClientResponse
    {
        [Key]
        [Display(Name ="Response Id")]
        public int ResponseID { get; set; }

       
        [Display(Name ="Adjective Id")]
        public int AdjectiveID { get; set; }
        
        [Display(Name ="Client Id")]
        public int ClientID { get; set; }

        
        
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        [ForeignKey("AdjectiveID")]
        public virtual Adjective Adjective { get; set; }

    }
}

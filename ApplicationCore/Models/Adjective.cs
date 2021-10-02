using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Adjective
    {
        [Key]
        public int AdjectiveID { get; set; }
        public string AdjName { get; set; }
        public string AdjDefinition { get; set; }
        [Range(0, 1, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int AdjType { get; set; }

    }
}

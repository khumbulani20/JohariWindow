using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Johari.ViewModels
{
    public class ClientVM
    {

        public Client Client { get; set; }
        public ClientResponse ClientResponse { get; set; }
        public IList<SelectListItem> AdjectivesList { get; set; }
        public List<Adjective> Adjectives { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Admin
{
    public class JohariModel : PageModel
    {
        public string ClientId { get; set; }
        public void OnGet(string id)
        {
            //run johari on id 
            ClientId = id;
        }
    }
}

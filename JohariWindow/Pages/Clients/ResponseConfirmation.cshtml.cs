using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Clients
{
    public class ResponseConfirmationModel : PageModel
    {
        [BindProperty]
        public string userName { get; set; }
        public void OnGet(string name)
        {
            userName = name;
        }
    }
}

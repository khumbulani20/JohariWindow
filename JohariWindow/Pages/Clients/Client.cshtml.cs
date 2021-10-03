using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Clients
{
    public class ClientModel : PageModel
    {
        public Client ClientObj { get; set; }
        [BindProperty]
        public string ApplicationUserId { get; set; }
      
        [BindProperty]
        public string EmailOne { get; set; }
        [BindProperty]
        public string EmailTwo { get; set; }
        [BindProperty]
        public string EmailThree { get; set; }
        [BindProperty]
        public string EmailFour { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public IActionResult OnGet(   )
        {

            //get the applicationuserid from aspnetusers table
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUserId = claim.Value;
           
            //ClientObj = new Client();
            ////edit category
            //if (email !=null)
            //{
            //    //get category with specified id 
            //    //access email for user
            //    ClientObj = _unitOfWork.Client.Get(u => u. == id);
            //    if (ClientObj == null) return NotFound();
            //}


            return Page();
        }

        //gets four emails and send to 
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //send emails

            Console.WriteLine(EmailOne);
            if(EmailOne!=null && EmailTwo!=null && EmailThree!=null && EmailFour!=null )
            {
                //send emails to friends
            }
           
            return RedirectToPage("./Upsert");
        }
    }
}

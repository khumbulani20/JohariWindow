using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JohariWindow.Pages.Clients
{
    public class ClientModel : PageModel
    {
        public Client ClientObj { get; set; }
        [BindProperty]
        public string ApplicationUserId { get; set; }



         



        List<EmailAddress> emails;
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
            emails = new List<EmailAddress>();
            //Console.WriteLine(EmailOne);
           
            EmailOne = Request.Form["email1"];
            EmailTwo = Request.Form["email2"];
            EmailThree = Request.Form["email3"];
            EmailFour = Request.Form["email4"];
            ApplicationUserId = Request.Form["userId"];
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(ApplicationUserId);
            //}

            if (EmailOne !=null && EmailTwo!=null && EmailThree!=null && EmailFour!=null )
            {
                Console.WriteLine(EmailOne);
                Console.WriteLine(EmailOne);
                emails.Add(new EmailAddress { Email=EmailOne});
                emails.Add(new EmailAddress { Email = EmailTwo });
                emails.Add(new EmailAddress { Email = EmailThree });
                emails.Add(new EmailAddress { Email = EmailFour });
                foreach(EmailAddress e in emails)
                {
                    Console.WriteLine(e.Email);
                }
                string callbackUrl = "test urls";
                string url = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                //send emails to friends
               
                _ = Execute(url,emails);
            }
           
            return RedirectToPage("./Upsert");
        }
        public async Task Execute(string url,List<EmailAddress> tos)
        {
            AuthSenderOptions aso = new AuthSenderOptions();
            Environment.SetEnvironmentVariable("SENDGRID_API_KEY", aso.SendGridKey);
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
         
           
            var from = new EmailAddress("joharibykn@gmail.com", "Admin email");




            
            var subject = "Johari window friend evaluation request";
            string callbackUrl = "https://www.google.com/";
            var htmlContent = $"Click link to evaluate friend <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Evaluate friend</a>.";
            //CreateSingleEmail(EmailAddress from, EmailAddress to, string subject, string plainTextContent, string htmlContent);
            var msg=  MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, url, htmlContent);
            
            var response = await client.SendEmailAsync(msg);
        }
    }
}

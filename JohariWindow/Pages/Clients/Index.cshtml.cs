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
    public class IndexModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
         
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
        private string userName;
        public IActionResult OnGet()
        {

            //get the applicationuserid from aspnetusers table
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //get first and last name
            

            if (claim==null)
            {
                return RedirectToPage();
            }
            else
            {
                ApplicationUserId = claim.Value;
                Client cl = _unitOfWork.Client.Get(u => u.ASPNETUserID == ApplicationUserId);
                int clientID = cl.ClientID;
                //get first and last name
                userName = cl.FirstName + " " + cl.LastName;
            }
            

          

            return Page();
        }

        //gets four emails and send to friends
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            emails = new List<EmailAddress>();
        

            EmailOne = Request.Form["email1"];
            EmailTwo = Request.Form["email2"];
            EmailThree = Request.Form["email3"];
            EmailFour = Request.Form["email4"];
            ApplicationUserId = Request.Form["userId"];
           

            if (EmailOne != null && EmailTwo != null && EmailThree != null && EmailFour != null)
            {
                Console.WriteLine(EmailOne);
                Console.WriteLine(EmailOne);
                emails.Add(new EmailAddress { Email = EmailOne });
                emails.Add(new EmailAddress { Email = EmailTwo });
                emails.Add(new EmailAddress { Email = EmailThree });
                emails.Add(new EmailAddress { Email = EmailFour });
                //needs first and last name
               
                string callbackUrl = "https://localhost:44376/Friends/Friend";
                string url = $"Please Evaluate your friend {userName} using this user id: {ApplicationUserId} <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                //send emails to friends

                _ = Execute(url, emails, userName);
            }

            return RedirectToPage("./Upsert");
        }
        public async Task Execute(string url, List<EmailAddress> tos, string name)
        {
            AuthSenderOptions aso = new AuthSenderOptions();
            Environment.SetEnvironmentVariable("SENDGRID_API_KEY", aso.SendGridKey);
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);


            var from = new EmailAddress("joharibykn@gmail.com", "Admin email");

            var subject = "Johari window friend evaluation request for  "+ name;
            //string callbackUrl = "https://johariwindowndlovu.azurewebsites.net/Friends/Friend";
            string callbackUrl = "https://localhost:44376/Friends/Friend";
            Console.WriteLine(userName);
            var htmlContent = $"Click link to   <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Evaluate </a>  {name} and enter the id : {ApplicationUserId}";
            //CreateSingleEmail(EmailAddress from, EmailAddress to, string subject, string plainTextContent, string htmlContent);
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, url, htmlContent);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Friends
{

    public class FriendModel : PageModel
    {
       
        //public string ApplicationUserId { get; set; }


     
        public Friend FriendObj { get; set; }
        public string howlong;
        public  string relationship;
        public string clientId;
        private readonly IUnitOfWork _unitofWork;
        public FriendModel(IUnitOfWork unitofWork) => _unitofWork = unitofWork;

      
        public IActionResult OnPost()
        {
            clientId = Request.Form["userId"];
            howlong = Request.Form["howlong"];
            relationship = Request.Form["relationship"];

            if (!ModelState.IsValid)
            {

                Console.WriteLine(" inside the model state");
                return Page();
            }

            //validate user id
            var client = _unitofWork.Client.Get(u => u.ASPNETUserID == clientId);
            if (client == null)
            {

                return Page();
            }
            Friend fr = new Friend
            {
                ASPNETUserID = clientId,
                HowLong = howlong,
                Relationship = relationship


            };

            _unitofWork.Friend.Add(fr);



            _unitofWork.Commit();
            //open friend response page
            return RedirectToPage("../Clients/Responses", new { id=clientId });
            
        }
    }
}


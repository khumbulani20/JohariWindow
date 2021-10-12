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
        public string friendId;
        public FriendModel(IUnitOfWork unitofWork) => _unitofWork = unitofWork;

        public IActionResult OnGet(string id)
        {
            if (id!=null)
            {
                friendId = id;
            }
            return Page();
        }
        public IActionResult OnPost(string id)
        {

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(id);
            }
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
            if(id!=null)
            {
                Friend friend = _unitofWork.Friend.Get(f => f.ASPNETUserID == id);
                friend.HowLong = howlong;
                friend.Relationship = relationship;
                //Friend fr = new Friend
                //{
                //    FriendID = friend.FriendID,
                //    ASPNETUserID = id,
                //    HowLong = howlong,
                //    Relationship = relationship


                //};
                Console.WriteLine("user id is " + id);
                //find user with this id
               
                _unitofWork.Friend.Update(friend);
                _unitofWork.Commit();
            }
           



            
            //open friend response page
            return RedirectToPage("../Clients/Responses", new { id=clientId });
            
        }
    }
}


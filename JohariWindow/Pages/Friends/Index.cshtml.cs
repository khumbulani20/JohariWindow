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
    public class IndexModel : PageModel
    {
      
        public string ApplicationUserId { get; set; }


        //binds with what's in the web page and backend for validation 
     
        private readonly IUnitOfWork _unitofWork;
        public IndexModel(IUnitOfWork unitofWork) => _unitofWork = unitofWork;

        public void OnGet(int? id)
        {
            //FriendObj = new Friend();
            ////edit category
            //if (id != 0)
            //{
            //    //get category with specified id
            //    FriendObj = _unitofWork.Friend.Get(u => u.FreindID == id);
            //    if (FriendObj == null) return NotFound();
            //}

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("get");
            }
            // return Page();
        }
        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                Console.WriteLine("model state check");
                return Page();
            }
            string id=null;
            ApplicationUserId = Request.Form["userId"];
            for(int i=0;i<100;i++)
            {
                Console.WriteLine("inside post");
            }
            Console.WriteLine(ApplicationUserId);
            //if new category
            if (ApplicationUserId !="")
            {
                //Console.WriteLine("inside");
                ////find application id
                //Client c = _unitofWork.Client.Get(u => u.ID.app== ApplicationUserId);
                //id = c.Id;
                //Console.WriteLine(id);
            }

            else
            {
                Console.WriteLine("nothing found");
            }
           // return Page();
            //open friend response page
            return RedirectToPage("./Friend");
        }
    }
}

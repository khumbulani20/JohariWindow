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
    public class UpsertModel : PageModel
    {
        //binds with what's in the web page and backend for validation 
        [BindProperty]
        public ClientResponse ClientResponse { get; set; }

        [BindProperty]
        public FriendResponse FriendResponse { get; set; }
        private readonly IUnitOfWork _unitofWork;
        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }
        public UpsertModel(IUnitOfWork unitofWork) => _unitofWork = unitofWork;

        //? means you can either have the parameter or not
        public IActionResult OnGet(string id)
        {
            //check if user is client or friend
            
             var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim!=null)
            {
                string user = claim.Value;
                if (user == id)
                {
                    //client
                    //check if user has responses
                    //use id to check database
                    Client client = _unitofWork.Client.Get(u => u.ASPNETUserID == id);
                    if (client != null)
                    {
                        ClientResponse = new ClientResponse();
                        //edit category
                        if (client.Id != 0)
                        {

                            ClientResponse = _unitofWork.ClientResponse.Get(u => u.ClientID == client.Id);
                            if (ClientResponse == null) return NotFound();
                        }
                    }


                }
            }
            else
            {
                //friend
                

            }
           
            


            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string user = claim.Value;
            if (user == null)
            {
                FriendResponse = new FriendResponse();
                //get submitted data

                _unitofWork.FriendResponse.Add(FriendResponse);
             
            }
            else
            {
                //if new category
                if (ClientResponse.ClientID == 0)
                {
                    _unitofWork.ClientResponse.Add(ClientResponse);
                }

                else
                {
                    _unitofWork.ClientResponse.Update(ClientResponse);
                }
            }
            _unitofWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}


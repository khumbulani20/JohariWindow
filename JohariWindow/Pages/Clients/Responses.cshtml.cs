using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Johari.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JohariWindow.Pages.Clients
{
    public class Responses : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public IList<SelectListItem> Adjectives { get; set; }
        [BindProperty]
        public ClientVM ClientObj { get; set; }

        //[BindProperty]
        //public Client Client { get; set; }

        [BindProperty]
        public ClientResponse ClientResponseObj { get; set; }

        public int Type { get; set; }

        [TempData]
        public string SelectedAdjectives { get; set; }
        [TempData]
        public string SelectedAdjectiveIDs { get; set; }

        public Responses(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void OnGet(string id)
        {

            Console.WriteLine(id);
            //check if user is client or not
            // var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            // var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //string user= claim.Value;
         //  string ix= Request.Form["userid"];
            //var adjectives = _unitOfWork.Adjective.List();
            List<Adjective> AdjectiveList = (List<Adjective>)_unitOfWork.Adjective.List();
            
            //create a positive and negative list
            ClientObj = new ClientVM
            {
                Client = new Client(),
                AdjectivesList = AdjectiveList.ToList<Adjective>().Select(f => new SelectListItem { Text = f.AdjName, Value = f.AdjectiveID.ToString() }).ToList<SelectListItem>(),
                ClientResponse = new ClientResponse()
                ,
                Adjectives = AdjectiveList


            };

        }





        public IActionResult OnPost()
        {

            //validation for when javascript is turned off on browser
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //check if user is client or friend
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {//client
                string user = claim.Value;

                //client
                //check if he has responses
                //user is the user id
                //use it to get responses
                Client client = _unitOfWork.Client.Get(u => u.ASPNETUserID == user);
                // ClientResponse respo = _unitOfWork.ClientResponse.Get(u=>u.ClientID==client.ClientID);

                //gets list of all responses
                IEnumerable<ClientResponse> list = _unitOfWork.ClientResponse.List(u => u.ClientID == client.ClientID);
                // _unitOfWork.ClientResponse.Update(ClientResponse);
                if (list.Count() > 0)//he has responses update
                {
                    List<int> ids = new List<int>();
                    //get the ids and update
                    foreach (ClientResponse c in list)
                    {
                        ids.Add(c.ResponseID);
                    }

                    int count = 0;
                    foreach (SelectListItem Adjective in ClientObj.AdjectivesList)
                    {
                        if (Adjective.Selected)
                        {
                            //create a response
                            ClientResponse resp = new ClientResponse();
                            try
                            {

                                //get client response from list and update
                                list.ElementAt(count).AdjectiveID = Int32.Parse(Adjective.Value);
                                list.ElementAt(count).ClientID = client.ClientID;
                                //resp.AdjectiveID = Int32.Parse(Adjective.Value);
                                //resp.ResponseID = ids[count];
                                //resp.ClientID = client.ClientID;

                                //check for adding more than the ones in db
                                //save to db
                                _unitOfWork.ClientResponse.Update(list.ElementAt(count));
                                if (count > list.Count())
                                {
                                    break;
                                }
                                count = count + 1;

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Unable to parse '{Adjective.Value}'");
                            }


                        }
                    }

                }
                else
                {//add new client responses

                    string idss = Request.Form["clientid"];

                    foreach (SelectListItem Adjective in ClientObj.AdjectivesList)
                    {
                        if (Adjective.Selected)
                        {
                            //create a response
                            ClientResponse resp = new ClientResponse();
                            try
                            {
                                resp.AdjectiveID = Int32.Parse(Adjective.Value);

                                resp.ClientID = client.ClientID;
                                //save to db
                                _unitOfWork.ClientResponse.Add(resp);

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Unable to parse '{Adjective.Value}'");
                            }


                        }
                    }



                }

            }

            else
            {
                //friend
                //create a friend response and save
                //get client id using application user id
                string cliId = Request.Form["userid"];

                Client cl = _unitOfWork.Client.Get(u => u.ASPNETUserID == cliId);
                int clID = cl.ClientID;
                foreach (SelectListItem Adjective in ClientObj.AdjectivesList)
                {
                    if (Adjective.Selected)
                    {
                        //create a response
                        FriendResponse resp = new FriendResponse();
                        try
                        {

                            resp.AdjectiveID = Int32.Parse(Adjective.Value);
                            resp.ClientID = clID;

                            _unitOfWork.FriendResponse.Add(resp);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Unable to parse '{Adjective.Value}'");
                        }


                    }
                }

            }


            _unitOfWork.Commit();
            return RedirectToPage("./Index");
            //return Page();
        }
    }
}

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
       [BindProperty]
        public string ClientId { get; set; }  


        public  string userName;
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public IList<SelectListItem> Adjectives { get; set; }
        [BindProperty]
        public ClientVM ClientObj { get; set; }

        //[BindProperty]
        public Client Client { get; set; }

        //[BindProperty]
        //public ClientResponse ClientResponseObj { get; set; }

        public int Type { get; set; }

       
        public Responses(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void OnGet(string id)
        {


            ClientId = id;
            if (id!=null)
            {
               Client= _unitOfWork.Client.Get(u => u.ASPNETUserID == id);
            }
           
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





        public IActionResult OnPost(string clientId)
        {
           
           
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //check if user is client or friend
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                //client
                string user = claim.Value;

                Client client = _unitOfWork.Client.Get(u => u.ASPNETUserID == user);
                // ClientResponse respo = _unitOfWork.ClientResponse.Get(u=>u.ClientID==client.ClientID);

                //gets list of all responses
                IEnumerable<ClientResponse> list = _unitOfWork.ClientResponse.List(u => u.ClientID == client.ClientID);
                // _unitOfWork.ClientResponse.Update(ClientResponse);
                if (list.Count() > 0)//he has responses update
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine(list.Count());
                    }
                   
                    List<int> ids = new List<int>();
                    //get the ids and update
                  
                    foreach (ClientResponse c in list)
                    {
                        ids.Add(c.ResponseID);
                    }
                    //check if user has 12 responses
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
                {
                    //add new client responses
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
                //friend responses

                if (clientId != null)
                {
                    Client cl = _unitOfWork.Client.Get(u => u.ASPNETUserID == clientId);
                    int clID = cl.ClientID;
                    //get first and last name
                    userName = cl.FirstName + " " + cl.LastName;
                    Console.WriteLine("the username is :" + userName);
                    foreach (SelectListItem Adjective in ClientObj.AdjectivesList)
                    {
                        if (Adjective.Selected)
                        {
                            //create a response
                            FriendResponse resp = new FriendResponse();
                            try
                            {

                                resp.AdjectiveID = Int32.Parse(Adjective.Value);
                                resp.ClientID = Client.ClientID;

                                _unitOfWork.FriendResponse.Add(resp);

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Unable to parse '{Adjective.Value}'");
                            }


                        }
                    }
                    _unitOfWork.Commit();
                    return RedirectToPage("./ResponseConfirmation", new { name = userName });
                }

                
            }

            _unitOfWork.Commit();
           
            return RedirectToPage("./Index");
        
        }
    }
}


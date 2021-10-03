using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Johari.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JohariWindow.Pages.Clients
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public IList<SelectListItem> Adjectives { get; set; }
        [BindProperty]
        public ClientVM ClientObj { get; set; }

        [BindProperty]
        public ClientResponse ClientResponseObj { get; set; }

        public int Type { get; set; }

        [TempData]
        public string SelectedAdjectives { get; set; }
        [TempData]
        public string SelectedAdjectiveIDs { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void OnGet()
        {
            int id = 1;
            //read data from adjectives table
            // var adjectives = _unitOfWork.Adjective.List();
            List<Adjective> AdjectiveList = (List<Adjective>)_unitOfWork.Adjective.List();
            foreach (Adjective a in AdjectiveList)
                Console.WriteLine(a.AdjectiveID);
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
            int id = 0;
            //validation for when javascript is turned off on browser
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == 0)
                foreach (SelectListItem Adjective in ClientObj.AdjectivesList)
                {
                    if (Adjective.Selected)
                    {
                        //create a response
                        ClientResponse resp = new ClientResponse();
                        try
                        {
                            resp.AdjectiveID = Int32.Parse(Adjective.Value);
                            resp.ClientID = 1;
                            //save to db
                            _unitOfWork.ClientResponse.Add(resp);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Unable to parse '{Adjective.Value}'");
                        }


                        //SelectedAdjectives = $"{Adjective.Text},{SelectedAdjectives}";
                        //SelectedAdjectiveIDs = $"{Adjective.Value},{SelectedAdjectiveIDs}";
                    }
                }
            //SelectedAdjectives = SelectedAdjectives.TrimEnd(',');
            //SelectedAdjectiveIDs = SelectedAdjectiveIDs.TrimEnd(',');
            //add New ClientResponse
            //foreach(var c in ClientObj.AdjectivesList)
            //{
            //    ClientResponseObj = new ClientResponse();
            //    ClientResponseObj.Client = ClientObj.Client;
            //    //c.Value is the adjective ID-
            //    ClientResponseObj.Adjective = ;
            //    _unitOfWork.ClientResponse.Add(ClientResponse);
            //}





            _unitOfWork.Commit();
            return RedirectToPage("./Client");

            //return Page();
        }
    }
}


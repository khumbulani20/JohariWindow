using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Admin
{
    public class JohariModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public JohariModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        private IEnumerable<FriendResponse> friendResponses;
        private IEnumerable<ClientResponse> clientResponses;
        public Client ClientObj { get; set; }
       public Dictionary<string, int> Queries { get; set; }
        public Dictionary<string, int> FQueries { get; set; }
        public List<string  > UQueries { get; set; }
        public string ClientId { get; set; }
        public void OnGet(int? id)
        {
            //run johari on id 
            ClientId =" "+ id;
            if (id!=0)
            {
               ClientObj= _unitOfWork.Client.Get(c => c.Id == id);
                if (ClientObj!=null)
                {
                    //get his responses
                    clientResponses = _unitOfWork.ClientResponse.List(cr => cr.ClientID == id);

                    //get his friend responses
                         friendResponses = _unitOfWork.FriendResponse.List(f => f.ClientID == id);

                    var result= from a in _unitOfWork.Adjective.List() 
                                join c in _unitOfWork.ClientResponse.List(cr => cr.ClientID == id)
                                on a.AdjectiveID equals c.AdjectiveID 
                                join f in _unitOfWork.FriendResponse.List(cr => cr.ClientID == id)
                                on c.AdjectiveID equals f.AdjectiveID
                                into Group
                                from f in Group.DefaultIfEmpty()
                                
                                select new
                                {
                                    AdjName=a.AdjName,
                                    
                                    Count=Group.Count()
                                  


                                };
                    var results = result.Distinct();
                    //foreach (var item in results)
                    //{
                       
                    //    Console.WriteLine(item.AdjName+" count "+item.Count );
                    //}
                    Dictionary<string, int> re = new Dictionary<string, int>();
                    foreach (var item in results)
                    {
                        re.Add(item.AdjName,item.Count);
                         
                    }
                    Queries = re;

                    //run johari

                    var result2 = from a in _unitOfWork.Adjective.List()
                                
                                 join f in _unitOfWork.FriendResponse.List(cr => cr.ClientID == id)
                                 on a.AdjectiveID equals f.AdjectiveID
                                 join c in _unitOfWork.ClientResponse.List(cr => cr.ClientID == id)
                                 on f.AdjectiveID equals c.AdjectiveID
                                  
                                 into Group
                                 from c in Group.DefaultIfEmpty()

                                 select new
                                 {
                                     AdjName = a.AdjName,

                                     Count = Group.Count()



                                 };
                    var friendResponsesOnly = result2.Distinct();
                    Dictionary<string, int> fro = new Dictionary<string, int>();
                    foreach (var item in friendResponsesOnly)
                    {
                        fro.Add(item.AdjName, item.Count);

                    }
                    FQueries = fro;
                    //foreach (var item in friendResponsesOnly)
                    //{
                    //    Console.WriteLine(item.AdjName + " count " + item.Count);
                    //}

                    //what is not in the other two lists


                    var result4 = (from a in _unitOfWork.FriendResponse.List() select a.AdjectiveID)
                                  .Union(from c in _unitOfWork.ClientResponse.List(cr => cr.ClientID == id) select c.AdjectiveID);

                               
                    var unknown = result4.Distinct() ;
                    List<  int> unknownList = new List<  int>();
                    foreach (var item in unknown)
                    {
                        unknownList.Add(item);
                   

                    }
                    unknownList.Sort();
                    foreach (var item in unknownList)
                    {
                        
                        Console.WriteLine(item);

                    }
                    ///
                    List<string> ul = new List<string>();
                    IEnumerable<Adjective> li = _unitOfWork.Adjective.List();
                    foreach (var item in li )
                    {
                        int temp=unknownList.Find(u=>u==item.AdjectiveID);
                        if (temp==0)
                        {
                            ul.Add(item.AdjName);
                        }
                    }
                    foreach (var item in ul)
                    {
                        Console.WriteLine(item);
                    }
                    UQueries = ul;
                }

            }


        }
    }
}

using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JohariWindow.Pages
{
    public class IndexModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            //check role of user
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if(claim!=null)
            {
                string user = claim.Value;
                //check friends table then direct user to fill out information
               Friend friend= _unitOfWork.Friend.Get(f=>f.ASPNETUserID==user);
                if (friend!=null)
                {
                    return RedirectToPage("./Friends/Friend", new { id = user });
                }
                
            }
            return Page();
 
        }
    }
}

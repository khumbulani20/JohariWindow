using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AdjectiveController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Adjective.List() });
        }

        

    }
}

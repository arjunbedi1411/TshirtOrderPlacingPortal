using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;


namespace TshirtOrderPlacingPortal.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TshirtController : ControllerBase
    {
        
     

        public TshirtController()
        {
         
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            return Ok();
        }

 
    }
}

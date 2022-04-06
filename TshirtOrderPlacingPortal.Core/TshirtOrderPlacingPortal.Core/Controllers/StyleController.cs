using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;


namespace TshirtOrderPlacingPortal.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StyleController : ControllerBase
    {
        private readonly IStyle _styleRepository;
        public StyleController(IStyle style)
        {
            _styleRepository = style;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _styleRepository.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetStyle(int id)
        {
            try
            {
                var item = await _styleRepository.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

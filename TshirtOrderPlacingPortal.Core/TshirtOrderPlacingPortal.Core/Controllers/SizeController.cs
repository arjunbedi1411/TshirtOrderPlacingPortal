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
    public class SizeController : ControllerBase
    {
        private readonly ISize _sizeRepository;
        public SizeController(ISize size)
        {
            _sizeRepository = size;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _sizeRepository.All();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetSize(int id)
        {
            try
            {
                var item = await _sizeRepository.GetById(id);

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

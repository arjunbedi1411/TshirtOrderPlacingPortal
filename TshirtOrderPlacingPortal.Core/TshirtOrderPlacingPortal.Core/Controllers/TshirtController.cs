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
        
        private readonly IUnitOfWork _unitOfWork;

        public TshirtController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.Tshirt.All();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTshirt(long id)
        {
            var item = await _unitOfWork.Tshirt.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTshirt(TShirt tshirt)
        {
            if (ModelState.IsValid)
            {
               tshirt.Id =0;

                await _unitOfWork.Tshirt.Add(tshirt);
                await _unitOfWork.CompleteAsync();

              //  return CreatedAtAction("GetTshirt", new { tshirt.Id }, tshirt);
                return CreatedAtAction("GetTshirt", new { tshirt.Id }, tshirt);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTshirt(long id)
        {
            var item = await _unitOfWork.Tshirt.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Tshirt.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}

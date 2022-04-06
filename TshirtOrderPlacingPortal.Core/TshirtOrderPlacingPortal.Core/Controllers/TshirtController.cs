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
    public class TshirtController : ControllerBase
    {
        private readonly ITshirt _tshirtRepository;
        public TshirtController(ITshirt tshirt)
        {
            _tshirtRepository = tshirt;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _tshirtRepository.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetTshirt(int id)
        {
            try
            {
                var item = await _tshirtRepository.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateTshirt(TShirt tshirt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tshirt.Id = 0;
                    await _tshirtRepository.Add(tshirt);
                    return CreatedAtAction("GetTshirt", new { tshirt.Id }, tshirt);
                }

                return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTshirt(int id)
        {
            try
            {
                var result = await _tshirtRepository.Delete(id);

                if (result == false)
                    return BadRequest();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateTshirt(TShirt tshirt)
        {
            try
            {
                var result = await _tshirtRepository.Upsert(tshirt);

                if (result == false)
                    return BadRequest();

                return CreatedAtAction("GetTshirt", new { tshirt.Id }, tshirt);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

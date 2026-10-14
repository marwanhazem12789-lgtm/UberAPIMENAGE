using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberAPIMENAGE.DTOs.RideDTOs;
using UberAPIMENAGE.Models;
using UberAPIMENAGE.UnitOfWorks;

namespace UberAPIMENAGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public RidesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await unitOfWork.Ride.GetById(id);
            var r = mapper.Map<GetAllRides>(t);
            return Ok(r);
        }

         [HttpPost]
        public async Task<IActionResult> Create(DTOs.RideDTOs.CreateRide dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();

            }

            var t = mapper.Map<Ride>(dto);
            await unitOfWork.Ride.Add(t);
            await unitOfWork.Save();
            return Created("", t);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> EdittoAccept(int id )
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var t =await unitOfWork.Ride.GetById(id);
            if (t == null)
            {
                return NotFound();
            }
            t.Status = "Accept";
            unitOfWork.Ride.Update(t);
            await unitOfWork.Save();
            return NoContent();

        }

        [HttpPatch("Complete/{id}")]
        public async Task<IActionResult> EdittoComplete(int id)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var t = await unitOfWork.Ride.GetById(id);
            if (t == null)
            {
                return NotFound();
            }
            t.Status = "Complete";
            unitOfWork.Ride.Update(t);
            await unitOfWork.Save();
            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await unitOfWork.Ride.GetById(id); if (t == null)
            {
                return NotFound();
            }
            unitOfWork.Ride.Remove(t);
            await unitOfWork.Save();
            return NoContent();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberAPIMENAGE.DTOs.UserDTOs;
using UberAPIMENAGE.DTOs.VehicleDTOs;
using UberAPIMENAGE.Models;
using UberAPIMENAGE.UnitOfWorks;

namespace UberAPIMENAGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var t = await unitOfWork.Vehicle.GetAll();
            var r = mapper.Map<List<DTOs.VehicleDTOs.GetAllVehicles>>(t);
            return Ok(r);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id , DTOs.VehicleDTOs.CreateVehicle dto)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var t =await unitOfWork.Vehicle.GetById(id);
            if(t == null)
            {
                return BadRequest();
            }
            var tt = mapper.Map(dto , t);
            unitOfWork.Vehicle.Update(tt);
           await unitOfWork.Save();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await unitOfWork.Vehicle.GetById(id);
            if (t == null)
            {
                return BadRequest();
            }

            unitOfWork.Vehicle.Remove(t);
            await unitOfWork.Save();
            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicle dto)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();

            }

            var t = mapper.Map<Vehicle>(dto);
           await unitOfWork.Vehicle.Add(t);
            await unitOfWork.Save();
            return Created("",t);
        }

    
    }
}

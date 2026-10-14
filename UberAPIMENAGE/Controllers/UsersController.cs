using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberAPIMENAGE.DTOs.AuthDTOs;
using UberAPIMENAGE.DTOs.UserDTOs;
using UberAPIMENAGE.UnitOfWorks;

namespace UberAPIMENAGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public UsersController(IUnitOfWork unitofwork , IMapper m)
        {
            _unitofwork = unitofwork;
            mapper = m;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTOs d)
        {
            var r = await _unitofwork.User.Login(d);
            if (r == null)
            {
                return NotFound();
            }
            return Ok(r);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var t = await _unitofwork.User.GetAll();
            var r = mapper.Map<List<GetAllUsers>>(t);
            return Ok(r);   
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string Name)
        {
            var t = await _unitofwork.User.Search(Name);
            return Ok(t);
        }

    }
}

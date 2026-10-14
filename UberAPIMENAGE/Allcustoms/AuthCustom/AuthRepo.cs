using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UberAPIMENAGE.DTOs.AuthDTOs;
using UberAPIMENAGE.DTOs.UserDTOs;
using UberAPIMENAGE.Genarics;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Allcustoms.AuthCustom
{
    public class AuthRepo :GenaricRepo<User> , IAuthRepo
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public AuthRepo(Context context , IConfiguration x) : base(context) 
        {
            _context = context;
            _configuration = x;
        }

        public async Task<string> Login(LoginRequestDTOs dto)
        {
            var t = await _context.users.Where(i => i.Email == dto.Email).FirstOrDefaultAsync();
            if (t == null)
            {
                throw new Exception();
            }
            if(t.Password == dto.Password)
            {
                return Token(t);
            }
            return null;
        }

        public async Task<List<GetAllUsers>> Search(string name)
        {
            return await _context.users.Where(o => o.FullName.Contains(name)).Select(i => new GetAllUsers
            {
                FullName = i.FullName,
                Email = i.Email,
                Id = i.Id,
                Password = i.Password,
                Phone = i.Phone,
                Role = i.Role,
            }).ToListAsync();
        }

        public string Token(User U)
        {
            var claims = new List<Claim>
            {
                new Claim("Name",U.FullName),
                new Claim("Email",U.Email),

            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var signingCredential = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var r = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Auddience"],
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["JWT:expireinhours"])),
               signingCredentials : signingCredential,
               claims : claims


                );

            var t = new JwtSecurityTokenHandler().WriteToken(r);
            return t;
        }
    }
}

using Microsoft.AspNetCore.Identity.Data;
using UberAPIMENAGE.DTOs.UserDTOs;
using UberAPIMENAGE.Genarics;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Allcustoms.AuthCustom
{
    public interface IAuthRepo : IGenaricRepo<User>
    {
        Task<string> Login(DTOs.AuthDTOs.LoginRequestDTOs dto);
        Task<List<GetAllUsers>> Search(string name);

    }
}

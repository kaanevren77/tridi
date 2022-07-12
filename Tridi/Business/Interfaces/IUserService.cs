using Tridi.Data.Dto;
using Tridi.Models;

namespace Tridi.Business.Interfaces
{
    public interface IUserService
    {
        Task<CustomResponseDto<UserModel>> Login(string email,string password);
    }
}

using Tridi.Data.Entities;

namespace Tridi.Data.Respository
{
    public interface IUserRespository
    {
        User Login(string email, string password);
    }
}

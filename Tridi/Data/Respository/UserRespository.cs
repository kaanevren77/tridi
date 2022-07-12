using Microsoft.EntityFrameworkCore;
using Tridi.Data.Entities;
using Tridi.Data.Respository.Base;

namespace Tridi.Data.Respository
{
    public class UserRespository : RespositoryBase<User>, IUserRespository
    {
        public UserRespository(TridiContext context) : base(context)
        {
        }

        public User Login(string email, string password)
        {        
               return  _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();         
        }
    }
}

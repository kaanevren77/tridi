using Tridi.Business.Interfaces;
using Tridi.Data.Dto;
using Tridi.Data.Entities;
using Tridi.Data.Respository;
using Tridi.Data.Respository.Base;
using Tridi.Data.Respository.UnitOfWork;
using Tridi.Models;
using AutoMapper;

namespace Tridi.Business.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRespository _userRespository;
        private readonly IMapper _mapper;
        public UserService(IRespositoryBase<User> repository, IUnitOfWork unitOfWork,IUserRespository userRespository,IMapper mapper) : base(repository, unitOfWork)
        {
            _userRespository = userRespository;
            _mapper = mapper;
        }


        public async Task<CustomResponseDto<UserModel>> Login(string email, string password)
        {
            var user =  _userRespository.Login(email, password);
            var userModel = _mapper.Map<UserModel>(user);
            return CustomResponseDto<UserModel>.Success(200, userModel);
        }
    }
}

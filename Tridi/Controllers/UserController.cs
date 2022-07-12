using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tridi.Business.Interfaces;
using Tridi.Controllers.Base;
using Tridi.Data.Dto;
using Tridi.Data.Entities;
using Tridi.Models;

namespace Tridi.Controllers
{
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IService<User> _service;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IService<User> service, IMapper mapper)
        {

            _userService = userService;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.GetAllAsync();
            var list = _mapper.Map<List<UserModel>>(users);
            var userId = GetSessionUser().Id;
            list = list.Where(x => x.Id != userId).ToList();

            return CreateActionResult(CustomResponseDto<List<UserModel>>.Success(200, list));
        }
    }
}

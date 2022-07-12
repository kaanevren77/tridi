using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tridi.Business.Interfaces;
using Tridi.Controllers.Base;
using Tridi.Data.Dto;
using Tridi.Data.Entities;
using Tridi.Filters;
using Tridi.Models;

namespace Tridi.Controllers
{
    [SessionCheckFilter]
    public class AppController : CustomBaseController
    {
 
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly IService<User> _service;
        private readonly IMapper _mapper;
        public AppController(IUserService userService, IService<User> service,IMessageService messageService,IMapper mapper)
        {

            _userService = userService;
            _messageService = messageService;
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Messages(int id)
        {
            ViewBag.Id = id;
            return View();
        }

    }
}

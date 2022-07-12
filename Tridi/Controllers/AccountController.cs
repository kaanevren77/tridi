using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tridi.Business.Interfaces;

namespace Tridi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            //login service
            var user = _userService.Login(email, password);

            if (user == null)
                return Json(false);


            Utilities.SessionExtensions.Set(HttpContext.Session, "Login", user.Result.Data);

            return Json(true);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Utilities.SessionExtensions.Remove(HttpContext.Session, "Login");
            return RedirectToAction("Index");
        }
    }
}

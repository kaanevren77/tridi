using Microsoft.AspNetCore.Mvc;
using Tridi.Data.Dto;
using Tridi.Models;

namespace Tridi.Controllers.Base
{
    public class CustomBaseController : Controller
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };


        }

        public UserModel GetSessionUser()
        {
            UserModel? user = Utilities.SessionExtensions.Get<UserModel>(HttpContext.Session, "Login");

            return user;
        }
    }
}

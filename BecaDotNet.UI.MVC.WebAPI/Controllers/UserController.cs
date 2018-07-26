using BecaDotNet.ApplicationService;
using BecaDotNet.UI.MVC.WebAPI.Models;
using System;
using System.Web.Http;

namespace BecaDotNet.UI.MVC.WebAPI.Controllers
{
    [RoutePrefix("becadotnet/api")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("user/auth")]
        public IHttpActionResult AuthUser(UserViewModel model)
        {
            string password;
            try
            {
                password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(model.password));
            }
            catch
            {
                return BadRequest();
            }

            try
            {
                var service = new UserService();
                var objUser = service.Get(model.login, password);
                if (objUser != null)
                    return Ok(objUser);
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}

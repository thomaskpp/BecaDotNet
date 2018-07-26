using BecaDotNet.ApplicationService;
using BecaDotNet.UI.MVC.Razor.Models;
using System;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.Razor.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CreateUser()
        {
            return PartialView("CreateUserPartialView", new CreateUserViewModel());
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel objModel)
        {
            try
            {
                var service = new UserService();
                var objUserToCreate = objModel.GetUser();
                var userCreateResult = service.Create(objUserToCreate);
                if(userCreateResult)
                    return RedirectToAction("Index");
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRoleManager_Core.Infrastructure.Repository;
using UserRoleManager_Core.Models;
using UserRoleManager_Core.Models.Permission;

namespace UserRoleManger_Mvc_UI.Controllers
{
    [Authorize("Permission")]
    public class HomeController : Controller
    {
        PermissionHandler permissionHandler;
        IHostingEnvironment host;
        IRepository<User> userRepository;
        public HomeController(IAuthorizationHandler permissionHandler, IHostingEnvironment host, IRepository<User> userRepository)
        {
            this.permissionHandler = permissionHandler as PermissionHandler;
            this.host = host;
            this.userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpGet("login")]
        public ActionResult Login(string returnUrl=null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(string userCode, string password, string returnUrl = null)
        {
            var user = userRepository.GetAll().SingleOrDefault(s => s.UserCode == userCode && s.Password == password);
            if (user == null)
            {
                const string badUserNameOrPasswordMessage = "用户名或密码错误！";
                return BadRequest(badUserNameOrPasswordMessage);
            }
                //用户标识
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.UserCode));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName));
            identity.AddClaim(new Claim("date", user.CreateDate.ToShortDateString()));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            if (returnUrl == null)
            {
                returnUrl = TempData["returnUrl"]?.ToString();
            }
            if (returnUrl == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
             return Redirect(returnUrl);

         
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
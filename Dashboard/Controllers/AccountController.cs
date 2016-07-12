using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Dashboard.Models;
using Dashboard.Security;
using System.Web.Security;

namespace Dashboard.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    bool showDefault = false;

                    if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/") showDefault = true;
                    if (!Url.IsLocalUrl(returnUrl)) showDefault = true;

                    if (showDefault) { return RedirectToAction("Index", "Home"); }
                    else { return Redirect(returnUrl); }

                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            }
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", null);
        }



        // GET: /Account/AccountInfo/

        //[HttpGet]
        //public ActionResult AccountInfo()
        //{
        //    var item = new gAgent(User.ToCustomPrincipal().CustomIdentity.UserId);
        //    if (!item.Exist) return HttpNotFound();

        //    var modelo = new UserInfoModel();
        //    modelo.id = item.Id;
        //    modelo.nombre = new Domain.CommonFunctions().GetUserName(item.Nombre, item.Apellidos);
        //    modelo.email = item.Email;
        //    modelo.login = item.LoginUser;
        //    modelo.roles = item.Roles;

        //    return View(modelo);
        //}


        // POST: /Account/UpdateAccountInfo/

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        //public ActionResult UpdateAccountInfo(UserInfoModel modelo)
        //{
        //    //if (!Request.IsAjaxRequest()) return HttpNotFound();
        //    if (ModelState.IsValid)
        //    {
        //        var item = new gAgent(modelo.id);
        //        if (!item.Exist)
        //        {
        //            ViewBag.ErrorMensaje = "El agente no es válido";
        //        }
        //        else
        //        {
        //            if (item.CheckPasswordValue(modelo.oldPassword))
        //            {
        //                item.SetLoginPassword(modelo.newPassword);
        //                if (item.Save())
        //                {
        //                    ViewBag.ErrorMensaje = "Contraseña cambiada correctamente.";
        //                }
        //                else
        //                {
        //                    ViewBag.ErrorMensaje = "Se ha producido un error al procesar la solicitud.";
        //                }
        //            }
        //            else
        //            {
        //                ViewBag.ErrorMensaje = "Los datos introducidos no son correctos.";
        //            }
        //        }
        //    }

        //    return View("AccountInfo", modelo);
        //}


    }
}
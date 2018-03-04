using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [customAuthorize]
    public class testController : Controller
    {
        // GET: test
        [AllowAnonymous]
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Authenticated()
        {
            var identity = Thread.CurrentPrincipal.IsInRole("admin");
            
            return View(identity);
        }
    }

    public class customAuthorizeAttribute
        : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
              Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("vibs"), new string[] {"admin" }
               );
            //base.OnAuthorization(filterContext);
        }
    }
}
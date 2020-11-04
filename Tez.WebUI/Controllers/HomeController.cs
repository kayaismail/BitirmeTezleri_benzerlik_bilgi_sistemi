using Islem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tez.BLL.Abstract;
using Tez.DAL.Concrete.EntityFramework;
using Tez.Entities;
using Tez.WebUI.Models;

namespace Tez.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public HomeController()
        {
            //System.Diagnostics.Debug.WriteLine(projeManager.Get(1).TezOzet);
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


    }
}
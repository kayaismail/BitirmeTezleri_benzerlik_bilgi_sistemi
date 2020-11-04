using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tez.BLL.Abstract;
using Tez.WebUI.Models;

namespace Tez.WebUI.Controllers
{
    [Authorize(Roles = "D")]
    public class ListeController : Controller
    {
        ITezFikirManager tezFikirManager;
        IDanismanManager danismanManager;
        IFakulteManager fakulteManager;
        IBolumManager bolumManager;
        IProjeManager projeManager;
        public ListeController(ITezFikirManager tezFikirManager,
            IDanismanManager danismanManager, IFakulteManager fakulteManager,
            IBolumManager bolumManager, IProjeManager projeManager)
        {
            //System.Diagnostics.Debug.WriteLine(projeManager.Get(1).TezOzet);
            this.tezFikirManager = tezFikirManager;
            this.danismanManager = danismanManager;
            this.fakulteManager = fakulteManager;
            this.bolumManager = bolumManager;
            this.projeManager = projeManager;
        }
        // GET: Liste
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FakulteListele()
        {
            return View(fakulteManager.GetAll());
        }
        public ActionResult DanismanListele()
        {
            return View(danismanManager.GetAll());
        }
        public ActionResult BolumListele()
        {
            BolumListele bolumListele = new BolumListele()
            {
                dbFakultes = fakulteManager.GetAll(),
                SecilenFakulteId = null,
                bolumler = null
            };

            return View(bolumListele);
        }
        [HttpPost]
        public ActionResult BolumListele(BolumListele bolumListele)
        {
            bolumListele.dbFakultes = fakulteManager.GetAll();
            bolumListele.bolumler = fakulteManager.Get(Convert.ToInt32(bolumListele.SecilenFakulteId)).Bolumler;
            return View(bolumListele);
        }
    }
}
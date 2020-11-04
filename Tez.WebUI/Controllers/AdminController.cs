using Islem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tez.BLL.Abstract;
using Tez.Entities;
using Tez.WebUI.Models;

namespace Tez.WebUI.Controllers
{
    [Authorize(Roles = "A")]
    public class AdminController : Controller
    {
        IDanismanManager danismanManager;
        IFakulteManager fakulteManager;
        IBolumManager bolumManager;
        IProjeManager projeManager;
        ICiktiManager ciktiManager;
        ITezManager tezManager;
        public AdminController(ICiktiManager ciktiManager,
            IDanismanManager danismanManager,IFakulteManager fakulteManager,
            IBolumManager bolumManager, IProjeManager projeManager,
            ITezManager tezManager
        )
        {
            //System.Diagnostics.Debug.WriteLine(projeManager.Get(1).TezOzet);
            this.danismanManager = danismanManager;
            this.fakulteManager  = fakulteManager;
            this.bolumManager    = bolumManager;
            this.projeManager    = projeManager;
            this.ciktiManager    = ciktiManager;
            this.tezManager      = tezManager;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanismanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DanismanEkle(dbDanisman dbDanisman)
        {
            danismanManager.Add(dbDanisman);

            return RedirectToAction("Index");
        }
        public ActionResult BolumEkle()
        {
            BolumFakulte bolumFakulte = new BolumFakulte()
            {
                dbBolum = new dbBolum(),
                dbFakultes = fakulteManager.GetAll(),
            };


            return View(bolumFakulte);
        }
        [HttpPost]
        public ActionResult BolumEkle(BolumFakulte bolumFakulte)
        {
            bolumFakulte.dbBolum.Fakulte = fakulteManager.Get(Convert.ToInt32(bolumFakulte.SecilenFakulteId));

            bolumManager.Add(bolumFakulte.dbBolum);

            return RedirectToAction("Index");
        }
        public ActionResult FakulteEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FakulteEkle(dbFakulte dbFakulte)
        {
            fakulteManager.Add(dbFakulte);
            return RedirectToAction("Index");
        }

        public ActionResult DanismanProjeEkle()
        {
            return View(new ProjeDanisman()
            {
                dbProje = new dbProje(),
                dbDanismen = danismanManager.GetAll(),
            });
        }
        [HttpPost]
        public ActionResult DanismanProjeEkle(ProjeDanisman projeDanisman)
        {
            projeDanisman.dbProje.Danisman = danismanManager.Get(Convert.ToInt32(projeDanisman.SecilenDanismanId));

            projeManager.Add(projeDanisman.dbProje);
            return RedirectToAction("Index");
        }
        public ActionResult YeniTezEkle()
        {
            return View(new YeniTezDanisman()
            {
                tez = new dbTez(),
                Danismanlar = danismanManager.GetAll()
            });
        }
        [HttpPost]
        public ActionResult YeniTezEkle(YeniTezDanisman tezDanisman)
        {
            tezDanisman.tez.Danisman = danismanManager.Get(tezDanisman.SecilenDanismanId).DanismanAd;
            tezDanisman.tez.Bolum = danismanManager.Get(tezDanisman.SecilenDanismanId).DanismanBolumu;
            tezManager.Add(tezDanisman.tez);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult SistemiGuncelle()
        {
            KelimeIslemleri kelimeIslemleri = new KelimeIslemleri(tezManager, ciktiManager);
            foreach (var item in bolumManager.GetAll())
            {
                kelimeIslemleri.SistemiGuncelle(tezManager.GetAll().Where(
                    c => c.Bolum.Id == item.Id).ToList());
            }
            return View();
        }
        public ActionResult TezListele()
        {
            return View(tezManager.GetAll());
        }
        public ActionResult Fakulteler()
        {
            return View(fakulteManager.GetAll());
        }
        public ActionResult Bolumler()
        {
            return View(bolumManager.GetAll());
        }
        public ActionResult FakulteSil(int id)
        {
            List<dbBolum> dbBolums = bolumManager.GetAll();
            foreach (var item in dbBolums)
            {
                if (item.Fakulte.Id == id)
                {
                    return View("FakulteHata");
                }
            }
            fakulteManager.Delete(fakulteManager.Get(id));
            return RedirectToAction("Fakulteler", "Admin");

        }
        public ActionResult BolumSil(int id)
        {

            List<dbTez> dbTezs = tezManager.GetAll();
            foreach (var item in dbTezs)
            {
                if (item.Bolum.Id == id)
                {
                    tezManager.Delete(item);
                }
            }
            List<dbDanisman> dbDanisman = danismanManager.GetAll();
            foreach (var item in dbDanisman)
            {
                if (item.DanismanBolumu.Id == id)
                {
                    danismanManager.Delete(danismanManager.Get(id));
                }
            }
            bolumManager.Delete(bolumManager.Get(id));
            return RedirectToAction("Bolumler", "Admin");
        }
    }
}
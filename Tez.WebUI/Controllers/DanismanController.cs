using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tez.BLL.Abstract;
using Tez.Entities;
using Tez.WebUI.Models;

namespace Tez.WebUI.Controllers
{
    [Authorize(Roles = "D")]
    public class DanismanController : Controller
    {
        IDanismanManager danismanManager;
        ITezFikirManager tezFikirManager;
        IOgrenciManager ogrenciManager;
        IProjeManager projeManager;
        IBolumManager bolumManager;
        public DanismanController(IOgrenciManager ogrenciManager, 
            IDanismanManager danismanManager, 
            ITezFikirManager tezFikirManager,
            IProjeManager projeManager,
            IBolumManager bolumManager)
        {
            this.danismanManager = danismanManager;
            this.tezFikirManager = tezFikirManager;
            this.ogrenciManager = ogrenciManager;
            this.projeManager = projeManager;
            this.bolumManager = bolumManager;
        }
        public ActionResult TezFikirleriListele()
        {
            List<dbTezFikir> temp = new List<dbTezFikir>();
            var TezFikirler = danismanManager.Get(User.Identity.Name).TezFikirleri;
            if(TezFikirler != null)
            {
                foreach (var item in danismanManager.Get(User.Identity.Name).TezFikirleri)
                {
                    temp.Add(item);
                }
            }
            return View(temp);
        }
        private static dbTezFikir tempTezFikir = null;
        public ActionResult Detaylar(int Id)
        {
            tempTezFikir = tezFikirManager.Get(Id);
            return View(tempTezFikir);
        }
        [HttpPost]
        public ActionResult Detaylar(dbTezFikir dbTezFikir)
        {
            tempTezFikir.FikirYorum = dbTezFikir.FikirYorum;
            tempTezFikir.TezFikirDurumu = dbTezFikir.TezFikirDurumu;
            tezFikirManager.Update(tempTezFikir);
            return RedirectToAction("TezFikirleriListele");
        }
        public ActionResult ProjeEkle()
        {
            return View(new dbProje());
        }
        [HttpPost]
        public ActionResult ProjeEkle(dbProje dbProje)
        {
            dbProje.Danisman = danismanManager.Get(User.Identity.Name);
            projeManager.Add(dbProje);
            return RedirectToAction("TezFikirleriListele");
        }
        public ActionResult ProjeListele()
        {
            List<dbProje> temp = projeManager.GetAll().Where(c => c.Danisman.DanismanMail == User.Identity.Name).ToList();
            return View(temp);
        }
        public ActionResult ProjeDetay(int Id)
        {
            return View(projeManager.Get(Id));
        }
        public ActionResult ProjeSil(int Id)
        {
            projeManager.Delete(projeManager.Get(Id));
            return RedirectToAction("ProjeListele");
        }
        public ActionResult Panel()
        {
            
            return View(new DanismanPanel()
            {
                KontenjanSayisi=danismanManager.Get(User.Identity.Name).DanismanKontenjan
            });
        }
        [HttpPost]
        public ActionResult Panel(DanismanPanel Dpanel)
        {
            if (Dpanel.YeniSifre == Dpanel.YeniSifreTekrar)
            {
                dbDanisman TempDanisman = danismanManager.Get(User.Identity.Name);
                if(Dpanel.MevcutSifre == TempDanisman.DanismanSifre)
                {
                    TempDanisman.DanismanSifre = Dpanel.YeniSifre;
                    TempDanisman.DanismanKontenjan = Dpanel.KontenjanSayisi;
                    danismanManager.Update(TempDanisman);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(new DanismanPanel()
            {
                KontenjanSayisi = danismanManager.Get(User.Identity.Name).DanismanKontenjan
            });

        }
    }
}
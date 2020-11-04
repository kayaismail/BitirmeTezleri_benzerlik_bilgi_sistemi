using Islem;
using Microsoft.Ajax.Utilities;
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
    [Authorize(Roles = "O")]
    public class OgrenciController : Controller
    {
        ITezFikirManager tezFikirManager;
        IDanismanManager danismanManager;
        IOgrenciManager ogrenciManager;
        IProjeManager projeManager;
        public OgrenciController(IDanismanManager danismanManager
                                ,ITezFikirManager tezFikirManager
                                ,IOgrenciManager ogrenciManager
                                ,IProjeManager projeManager)
        {
            this.danismanManager = danismanManager;
            this.tezFikirManager = tezFikirManager;
            this.ogrenciManager = ogrenciManager;
            this.projeManager = projeManager;
        }

        public ActionResult TezFikirEkle()
        {
            /* List<SelectListItem> selectListItems = new List<SelectListItem>();
             foreach (var item in danismanManager.GetAll())
             {
                 selectListItems.Add(new SelectListItem()
                 {
                     Text = item.DanismanAd, 
                     Value = item.Id.ToString(),
                     Selected = true
                 });
             }
             */
            List<dbDanisman> temp = danismanManager.GetAll().Where(c => c.DanismanBolumu.Fakulte.Id == ogrenciManager.Get(User.Identity.Name).Bolum.Fakulte.Id).ToList();
            var d = temp;
            TezFikirDanisman tezFikirDanisman = new TezFikirDanisman
            {
                tezFikir = new Entities.dbTezFikir(),
                dbDanismen = temp,
                SecilenDanismanId = ""
            };
            return View(tezFikirDanisman);
        }
        [HttpPost]
        public ActionResult TezFikirEkle(TezFikirDanisman tezFikirDanisman)
        {
           
            tezFikirDanisman.tezFikir.Danisman = danismanManager.Get(Convert.ToInt32(tezFikirDanisman.SecilenDanismanId));
            tezFikirDanisman.tezFikir.Gonderen = ogrenciManager.Get(User.Identity.Name);
            tezFikirDanisman.tezFikir.FikirYorum = "";
            tezFikirManager.Add(tezFikirDanisman.tezFikir);


            return RedirectToAction("Index","Home");

        }
        public ActionResult TezFikirListe()
        {
            var s = ogrenciManager.Get(User.Identity.Name).TezFikirleri;
            if (s == null)
            {
                return View(new List<dbTezFikir>());
            }
            return View(s);
        }
        public ActionResult Delete(int id)
        {
           
            tezFikirManager.Delete(tezFikirManager.Get(id));
            return RedirectToAction("TezFikirListe", "Ogrenci");
        }
        public ActionResult DanismanProjeleriListele()
        {
            List<dbProje> projeler = projeManager.GetAll();
            if(projeler.Where(c => c.Danisman.DanismanBolumu.Id ==
            ogrenciManager.Get(User.Identity.Name).Bolum.Id) == null)
            {
                return View(new List<dbProje>());
            }
            return View(projeler.Where(c => c.Danisman.DanismanBolumu.Id ==
            ogrenciManager.Get(User.Identity.Name).Bolum.Id));
        }
        public ActionResult DanismanListesi()
        {
            List<dbDanisman> temp = danismanManager.GetAll().ToList();
            return View(temp.Where(c => c.DanismanBolumu.Id == ogrenciManager.Get(User.Identity.Name).Bolum.Id));
        }
        public ActionResult Panel()
        {
            return View(new OgrenciPanel());
        }
        [HttpPost]
        public ActionResult Panel(OgrenciPanel PanelOgrenci)
        {

            if (PanelOgrenci.YeniSifre == PanelOgrenci.YeniSifreTekrar)
            {
                dbOgrenci TempOgrenci = ogrenciManager.Get(User.Identity.Name);
                if (PanelOgrenci.MevcutSifre == TempOgrenci.OgrenciSifre)
                {
                    TempOgrenci.OgrenciSifre = PanelOgrenci.YeniSifre;
                    ogrenciManager.Update(TempOgrenci);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(new OgrenciPanel());
        }


        public ActionResult TezGiris()
        {
            ViewBag.Message = "Your contact page.";

            return View(new TezGirdi());
        }
        [HttpPost]
        public ActionResult TezGiris(TezGirdi tez)
        {
            var d = tez;
            ViewBag.Message = "Your contact page.";
            if (tez.OgrenciAd2 == null)
            {
                tez.OgrenciAd2 = " ";
                tez.OgrenciNo2 = " ";
            }
            if (tez.OgrenciAd3 == null)
            {
                tez.OgrenciAd3 = " ";
                tez.OgrenciNo3 = " ";
            }
            if (tez.OgrenciAd4 == null)
            {
                tez.OgrenciAd4 = " ";
                tez.OgrenciNo4 = " ";
            }
            if (tez.OgrenciAd5 == null)
            {
                tez.OgrenciAd5 = " ";
                tez.OgrenciNo5 = " ";
            }
            if (tez.OgrenciAd6 == null)
            {
                tez.OgrenciAd6 = " ";
                tez.OgrenciNo6 = " ";
            }
            TezGirdiIslem islem;
            //Parametrelerde sasirmazsak iyidir
            IslemTezGirdi tezGirdi = new IslemTezGirdi(tez.BitirmeTeziMi, tez.OgrenciAd1, tez.OgrenciNo1,
                tez.OgrenciAd2, tez.OgrenciNo2, tez.OgrenciAd3, tez.OgrenciNo3, tez.OgrenciAd4, tez.OgrenciNo4,
                tez.OgrenciAd5, tez.OgrenciNo5, tez.OgrenciAd6, tez.OgrenciNo6, tez.Danisman,
                tez.Konu, tez.Yapilacaklar, tez.Tarih);
            islem = new TezGirdiIslem(tezGirdi);

            return RedirectToAction("Index");
        }
    }
}
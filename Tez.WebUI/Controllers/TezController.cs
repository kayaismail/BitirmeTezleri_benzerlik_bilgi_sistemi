using Islem;
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
    public class TezController : Controller
    {
        // GET: Tez
        public int PageSize = 20;
        ITezManager projeManager;
        public TezController(ITezManager projeManager)
        {
            //System.Diagnostics.Debug.WriteLine(projeManager.Get(1).TezOzet);
            this.projeManager = projeManager;
        }
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            List<dbTez> tezler = projeManager.GetAll().ToList();
            return View(new Tezler
            {
                tezs = tezler.Skip((page-1)*PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = tezler.Count,
                    CurrentPage = page
                }
            });
        }

        [HttpPost]
        public ActionResult Index(dbTez proje)
        {

            if (ModelState.IsValid)
            {
               // projeManager.Add(proje);
                return View("Basarili");
            }

            return View("Basarisiz");
        

        }
        public ActionResult Merhaba()
        {
            return RedirectToAction("Index");
        }
        public ActionResult Detay(int id)
        {

            return PartialView(projeManager.Get(id));
        }

        public ActionResult Benzerlik(int page = 1)
        {
            ViewBag.Message = "Your application description page.";

            List<dbTez> tezler = projeManager.GetAll().ToList();

            return View(new Tezler
            {
                tezs = tezler.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = tezler.Count,
                    CurrentPage = page
                },
            });
        }
        [HttpPost]
        public ActionResult Benzerlik(string aranacak_kelime)
        {
            KarsilastirmaIslem karsilastirma = new KarsilastirmaIslem(projeManager);
            Dictionary<dbTez, float> sozluk = karsilastirma.KarsilastirmaBaslat(aranacak_kelime);
            List<dbTez> tezler = sozluk.Keys.ToList();


            return View(new Tezler
            {
                tezs = tezler.Skip((1 - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = tezler.Count,
                    CurrentPage = 1
                },
                TezBenzerlikSozluk = sozluk
            });
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
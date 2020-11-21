using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tez.BLL.Abstract;
using Tez.DAL.Concrete.EntityFramework;
using Tez.Entities;
using Tez.WebUI.Models;

namespace Tez.WebUI.Controllers
{
    [AllowAnonymous]
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik

        IOgrenciManager ogrenciManager;
        IDanismanManager danismanManager;
        IBolumManager bolumManager;

        public GuvenlikController(IOgrenciManager ogrenciManager
                                 ,IDanismanManager danismanManager
                                 ,IBolumManager bolumManager)
        {
            this.ogrenciManager = ogrenciManager;
            this.bolumManager = bolumManager;
            this.danismanManager = danismanManager;
        }
        public ActionResult Giris()
        { //kod sadece ilk calistirildiginda database olusmasi icin calistirilmasi gereken iki satir 
          // TezContext tez = new TezContext();
          //  tez.Database.Create();
            return View(new GirisSayfasi());
        }
        [HttpPost]

        public ActionResult Giris(GirisSayfasi girisVerileri)
        {
            try
            {
                var temp = girisVerileri.MailAdresi.Split('@')[1];

                if (temp == "sakarya.edu.tr")
                {
                    if (danismanManager.GirisKontrolu(girisVerileri.MailAdresi, girisVerileri.Sifre))
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie(girisVerileri.MailAdresi, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(new GirisSayfasi());
                    }
                }
                else if (temp == "ogr.sakarya.edu.tr")
                {
                    if (ogrenciManager.GirisKontrolu(girisVerileri.MailAdresi, girisVerileri.Sifre))
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie(girisVerileri.MailAdresi, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(new GirisSayfasi());
                    }
                }
                else
                {
                    if (temp == "admin" && girisVerileri.Sifre == "123")
                    {

                        System.Web.Security.FormsAuthentication.SetAuthCookie(girisVerileri.MailAdresi, false);
                        return RedirectToAction("Index", "Home"); ;
                    }
                    return View(new GirisSayfasi());
                }
            }catch(Exception ex)
            {
                return View(new GirisSayfasi());
            }
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris");
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OgrenciKayit()
        {
            return View(new OgrenciBolum
            {
                dbBolums = bolumManager.GetAll(),
                dbOgrenci = new dbOgrenci()
            });
        }
        [HttpPost]
        public ActionResult OgrenciKayit(OgrenciBolum ogrenciBolum)
        {
            ogrenciBolum.dbOgrenci.Bolum = bolumManager.Get(ogrenciBolum.SecilenBolumId);

            if (ogrenciManager.Add(ogrenciBolum.dbOgrenci))
                return RedirectToAction("Index", "Home");
            else
            {
                return View(new OgrenciBolum
                {
                    dbBolums = bolumManager.GetAll(),
                    dbOgrenci = new dbOgrenci()
                });
            }
        }
        public ActionResult DanismanKayit()
        {
            return View(new DanismanBolum
            {
                dbBolums = bolumManager.GetAll(),
                dbDanisman = new dbDanisman()
            });
        }
        [HttpPost]
        public ActionResult DanismanKayit(DanismanBolum danismanBolum)
        {
            danismanBolum.dbDanisman.DanismanBolumu = bolumManager.Get(danismanBolum.SecilenBolumId);

            if (danismanManager.Add(danismanBolum.dbDanisman))
                return RedirectToAction("Index", "Home");
            else
            {
                return View(new DanismanBolum
                {
                    dbBolums = bolumManager.GetAll(),
                    dbDanisman = new dbDanisman()
                });
            }
        }


    }
}

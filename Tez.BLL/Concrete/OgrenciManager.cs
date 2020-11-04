using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Tez.BLL.Abstract;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.BLL.Concrete
{
	public class OgrenciManager : IOgrenciManager
	{

        private IOgrenciDal ogrenciDal;
        public OgrenciManager(IOgrenciDal ogrenciDal)
        {
            this.ogrenciDal = ogrenciDal;
        }

        public bool Add(dbOgrenci Veri)
        {
            
            if(HesapKontrol(Veri))
            {

                Veri.OgrenciSifre = SifreOlustur();
                if (MailAt(Veri.OgrenciMail, "Hesap Sifresi", "Merhaba, Hesabinizin Sifresi :" + Veri.OgrenciSifre +
                    "  Olarak Belirlenmistir"))
                {
                    System.Diagnostics.Debug.WriteLine(Veri.OgrenciMail + " e Mail Gonderildi. " + SifreOlustur());
                    this.ogrenciDal.Add(Veri);
                }
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool HesapKontrol(dbOgrenci Veri)
        {
            string MailKontrol = "";
            if (Veri.OgrenciMail == "") {
                return false;
            }
            if (Veri.OgrenciMail.Split('@').Length > 0) {
                MailKontrol = Veri.OgrenciMail.Split('@')[1];
            }
            System.Diagnostics.Debug.WriteLine(MailKontrol);
            if (MailKontrol == "ogr.sakarya.edu.tr")
            {
                if (ogrenciDal.Get(Veri.OgrenciMail) == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private static string SifreOlustur()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString.Substring(0, 8);
        }

        private static bool MailAt(string mail, string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("sautezsistemi@hotmail.com");
            //
            ePosta.To.Add(mail);
            //
            ePosta.Subject = konu;
            //
            ePosta.Body = icerik;
            //
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential("sautezsistemi@hotmail.com", "tezbenzerlik54");
            smtp.Port = 587;
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.Send(ePosta);
                
                return kontrol; 
            }
            catch (SmtpException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;

            }
        }


        public void Delete(dbOgrenci Veri)
        {
            this.ogrenciDal.Delete(Veri);
        }

        public dbOgrenci Get(string mail)
        {
            return this.ogrenciDal.Get(mail);
        }
        public bool GirisKontrolu(string mail,string Sifre)
        {
            try
            {
                dbOgrenci dbOgrenci = this.ogrenciDal.Get(mail);
                if (dbOgrenci.OgrenciSifre == Sifre)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public List<dbOgrenci> GetAll()
        {
            return this.ogrenciDal.GetAll();
        }
        public void Update(dbOgrenci ogrenci)
        {
            this.ogrenciDal.Update(ogrenci);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Tez.BLL.Abstract;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.BLL.Concrete
{
	public class DanismanManager : IDanismanManager
    {
        private IDanismanDal danismanDal;
        public DanismanManager(IDanismanDal danismanDal)
        {
            this.danismanDal = danismanDal;
        }

        public bool Add(dbDanisman Veri)
        {

            if (HesapKontrol(Veri))
            {

                Veri.DanismanSifre = SifreOlustur();
                if (MailAt(Veri.DanismanMail, "Hesap Sifresi", "Merhaba, Hesabinizin Sifresi :" + Veri.DanismanSifre +
                    " Olarak Belirlenmistir"))
                {
                    System.Diagnostics.Debug.WriteLine(Veri.DanismanMail + " e Mail Gonderildi. " + SifreOlustur());
                    this.danismanDal.Add(Veri);
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Delete(dbDanisman Veri)
        {
            this.danismanDal.Delete(Veri);
        }

        public dbDanisman Get(int Id)
        {
            return this.danismanDal.Get(Id);
        }

        public dbDanisman Get(string mail)
        {
            return this.danismanDal.Get(mail);
        }

        public List<dbDanisman> GetAll()
        {
            return this.danismanDal.GetAll();
        }

        public bool GirisKontrolu(string mail, string Sifre)
        {
            try
            {
                dbDanisman dbDanisman = this.danismanDal.Get(mail);
                if (dbDanisman == null)
                {
                    return false;
                }
                if (dbDanisman.DanismanSifre == Sifre)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool HesapKontrol(dbDanisman Veri)
        {
            string MailKontrol = "";
            if (Veri.DanismanMail == "")
            {
                return false;
            }
            if (Veri.DanismanMail.Split('@').Length > 0)
            {
                MailKontrol = Veri.DanismanMail.Split('@')[1];
            }
            System.Diagnostics.Debug.WriteLine(MailKontrol);
            if (MailKontrol == "sakarya.edu.tr")
            {
                if (danismanDal.Get(Veri.DanismanMail) == null)
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

        public void Update(dbDanisman danisman)
        {
            this.danismanDal.Update(danisman);
        }
    }
}

using Islem;
using MetinAnalizi;
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.BLL.Concrete;
using Tez.DAL.Concrete.EntityFramework;
using Tez.Entities;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Islemler
{
	class Program
	{
		static void Main(string[] args)
		{
			
			
			
			TezContext tez = new TezContext();
			EfDanismanDal efDanismanDal = new EfDanismanDal();
			dbDanisman db = new dbDanisman();
			db.DanismanAd = "Doktor";
			db.DanismanKontenjan = 2;
			efDanismanDal.Add(db);
			


		}
	}
}
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Islem
{
	public class TezGirdiIslem
	{
		string s = "", temp;
		public TezGirdiIslem(IslemTezGirdi tez)
		{
			//DENEME.HTML YI ISS EXPRESSTEN ALIYOR C:PROGRAM FILES86/IIS
			StreamReader sr = new StreamReader("C:\\Users\\ismailkaya\\Desktop\\Tezbilgi\\deneme.html");
			

			while ((temp = sr.ReadLine()) != null)
			{
				s += temp;
			}
			AyarlamalarYap(tez);

			PdfDocument pdf = PdfGenerator.GeneratePdf(s, PageSize.A4);
			pdf.Save("C:\\Users\\ismailkaya\\Desktop\\Konubelirlemeform.pdf");
		}

		private void AyarlamalarYap(IslemTezGirdi tez)
		{
			
			var d = tez;
			if (tez.BitirmeTeziMi)
			{
				s = s.Replace("@_2", "X");
				s = s.Replace("@_1", ".");
			}
			else
			{
				s = s.Replace("@_1", "X");
				s = s.Replace("@_2", ".");
			}
			s = s.Replace("@Ad1", tez.OgrenciAd1);
			s = s.Replace("@Ad2", tez.OgrenciAd2);
			s = s.Replace("@Ad3", tez.OgrenciAd3);
			s = s.Replace("@Ad4", tez.OgrenciAd4);
			s = s.Replace("@Ad5", tez.OgrenciAd5);
			s = s.Replace("@Ad6", tez.OgrenciAd6); 
			s = s.Replace("@Numara1", tez.OgrenciNo1);
			s = s.Replace("@Numara2", tez.OgrenciNo2);
			s = s.Replace("@Numara3", tez.OgrenciNo3);
			s = s.Replace("@Numara4", tez.OgrenciNo4);
			s = s.Replace("@Numara5", tez.OgrenciNo5);
			s = s.Replace("@Numara6", tez.OgrenciNo6);
			s = s.Replace("@Danisman", tez.Danisman);
			s = s.Replace("@Konu", tez.Konu);
			s = s.Replace("@Yapilacaklar", tez.Yapilacaklar);
			s = s.Replace("@Tarih", tez.Tarih);

		}
	}
}

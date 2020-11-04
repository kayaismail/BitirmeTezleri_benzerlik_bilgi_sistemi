using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tez.Entities
{
	public class IslemTezGirdi
	{
		public IslemTezGirdi(bool bitirmeTeziMi, string ogrenciAd1, string ogrenciNo1, string ogrenciAd2, 
			string ogrenciNo2, string ogrenciAd3, string ogrenciNo3, string ogrenciAd4, string ogrenciNo4,
			string ogrenciAd5, string ogrenciNo5, string ogrenciAd6, string ogrenciNo6,
			string danisman, string konu, string yapilacaklar, string tarih)
		{
			BitirmeTeziMi = bitirmeTeziMi;
			OgrenciAd1 = ogrenciAd1;
			OgrenciNo1 = ogrenciNo1;
			OgrenciAd2 = ogrenciAd2;
			OgrenciNo2 = ogrenciNo2;
			OgrenciAd3 = ogrenciAd3;
			OgrenciNo3 = ogrenciNo3;
			OgrenciAd4 = ogrenciAd4;
			OgrenciNo4 = ogrenciNo4;
			OgrenciAd5 = ogrenciAd5;
			OgrenciNo5 = ogrenciNo5;
			OgrenciAd6 = ogrenciAd6;
			OgrenciNo6 = ogrenciNo6;

			Danisman = danisman;
			Konu = konu;
			Yapilacaklar = yapilacaklar;
			Tarih = tarih;
		}

		public bool BitirmeTeziMi { get; set; }
		public string OgrenciAd1 { get; set; }
		public string OgrenciNo1 { get; set; }
		public string OgrenciAd2 { get; set; }
		public string OgrenciNo2 { get; set; }
		public string OgrenciAd3 { get; set; }
		public string OgrenciNo3 { get; set; }
		public string OgrenciAd4 { get; set; }
		public string OgrenciNo4 { get; set; }
		public string OgrenciAd5 { get; set; }
		public string OgrenciNo5 { get; set; }
		public string OgrenciAd6 { get; set; }
		public string OgrenciNo6 { get; set; }
		public string Danisman { get; set; }
		public string Konu { get; set; }
		public string Yapilacaklar { get; set; }
		public string Tarih { get; set; }


	}
}

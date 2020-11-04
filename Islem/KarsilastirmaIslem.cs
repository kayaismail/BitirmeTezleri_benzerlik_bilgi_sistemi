using MetinAnalizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.BLL.Abstract;
using Tez.BLL.Concrete;
using Tez.DAL.Concrete.EntityFramework;
using Tez.Entities;

namespace Islem
{
	public class KarsilastirmaIslem
	{


		const int BaslikAgirlik = 2;
		const int OzetAgirlik = 1;
		const int KeywordAgirlik = 3;
		const int ToplamAgirlik = BaslikAgirlik+OzetAgirlik;
		ITezManager tezManager;

		public KarsilastirmaIslem(ITezManager tezManager)
		{
			this.tezManager = tezManager;
		}


		public Dictionary<dbTez,float> KarsilastirmaBaslat(string girdiMetin)
		{
			float benzerlikOrani=0;
			int AgirlikDegeri = 0;
			Metin metin = new Metin(girdiMetin);
			List<string> gelenKelimeler = metin.MetinKelimeler();
			float ToplamKelimeKaysayisi = gelenKelimeler.Count * ToplamAgirlik;
			girdiMetin = girdiMetin.ToLower();
			string[] KeywordKarsilastirma = girdiMetin.Split(' ');

			List<string> VeritabaniKelimeler;
			Dictionary<dbTez, float> Sonuclar = new Dictionary<dbTez, float>();
			List<dbTez> liste = tezManager.GetAll().ToList();
			int BaslikIndexTutucu = -5;
			int BaslikPuanKatlayici = 1;
			foreach (var item in liste)
			{

				VeritabaniKelimeler = item.BaslikKelime.Split('|').ToList();
				for (int i = 0; i < gelenKelimeler.Count; i++)
				{
					for (int j = 0; j < VeritabaniKelimeler.Count; j++)
					{
						if (gelenKelimeler[i] == VeritabaniKelimeler[j])
						{
							if (BaslikIndexTutucu >= 0 && (BaslikIndexTutucu + 1) == j)
							{
								AgirlikDegeri += BaslikPuanKatlayici;
								BaslikPuanKatlayici++;
						//		System.Diagnostics.Debug.WriteLine("Baslik Katlayici Artiyor " + BaslikPuanKatlayici);
							}
							else
							{
								BaslikPuanKatlayici = 1;
							}
						//	System.Diagnostics.Debug.WriteLine(i+" BASLIK ESLESMELERI INDEX"+j );
							AgirlikDegeri += BaslikAgirlik;
						//	System.Diagnostics.Debug.WriteLine(ToplamAgirlik + " BASLIK ESLESTI " + AgirlikDegeri);
							BaslikIndexTutucu = j;
							break;
						}
					}
				}

				VeritabaniKelimeler = item.OzetKelime.Split('|').ToList();
				for (int i = 0; i < gelenKelimeler.Count; i++)
				{
					for (int j = 0; j < VeritabaniKelimeler.Count; j++)
					{
						if (gelenKelimeler[i] == VeritabaniKelimeler[j])
						{

							AgirlikDegeri += OzetAgirlik;
						//	System.Diagnostics.Debug.WriteLine( ToplamAgirlik+" OZET ESLESTI "+AgirlikDegeri);
							break;
						}
					}
				}

				VeritabaniKelimeler = item.KeywordsKelime.Split('|').ToList();
				for (int i = 0; i < KeywordKarsilastirma.Length; i++)
				{
					for (int j = 0; j < VeritabaniKelimeler.Count; j++)
					{
						
						if (KeywordKarsilastirma[i] == VeritabaniKelimeler[j])
						{
							AgirlikDegeri += KeywordAgirlik;
							
							//System.Diagnostics.Debug.WriteLine(ToplamAgirlik + " KEYWORD ESLESTI " + AgirlikDegeri);

							break;

						}
					}
				}
				benzerlikOrani = AgirlikDegeri / ToplamKelimeKaysayisi * 100;
				System.Diagnostics.Debug.WriteLine("BENZERLIK ORANI  " + benzerlikOrani);
				if (benzerlikOrani > 100)
				{
					System.Diagnostics.Debug.WriteLine("BENZERLIK ORANI 100leniyor " + benzerlikOrani);
					benzerlikOrani = 100;
				}

				if (benzerlikOrani != 0)
				{
					Sonuclar.Add(item, benzerlikOrani);
				}
				AgirlikDegeri = 0;
			}
			Sonuclar = Sonuclar.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
			
			for (int i = 0; i < Sonuclar.Count; i++)
			{
			//	Console.WriteLine(Sonuclar.Keys.ToList()[i] + " | " + Sonuclar.Values.ToList()[i]);
				//System.Diagnostics.Debug.WriteLine(Sonuclar.Keys.ToList()[i] + " | " + Sonuclar.Values.ToList()[i]+" | "+ToplamKelimeKaysayisi);
			}

			return Sonuclar;
		}

	}
}

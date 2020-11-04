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

	public class KelimeIslemleri
	{
		ITezManager tezManager;
		ICiktiManager ciktiManager;
		public KelimeIslemleri()
		{
			ciktiManager = new CiktiManager(new EfCiktiDal());
			tezManager = new TezManager(new EfTezDal());
		}
		public KelimeIslemleri(ITezManager tezManager,ICiktiManager ciktiManager)
		{
			this.ciktiManager = ciktiManager;
			this.tezManager = tezManager;
		}
		public void SistemiGuncelle(List<dbTez> tez)
		{
			if (tez.Count > 0)
			{
				CiktiKelimelerAyarla(tez);
				BaslikKelimelerAyarla(tez);
				OzetKelimelerAyarla(tez);
				KeywordKelimelerAyarla(tez);
				YeniKeywordsAyarla(tez);
			}
		}

		public void CiktiKelimelerAyarla(List<dbTez> tez)
		{

			string gmetin = "";

			for (int i = 0; i < tez.Count; i++)
			{
				gmetin += tez[i].TezOzet;

			}

			Metin metin = new Metin(gmetin);
			Dictionary<string, int> sozluk = metin.SozlukGetir();
			string sonMetin = "";
			foreach (var item in sozluk)
			{
				if (item.Value < 50)
					sonMetin += item.Key + "|";
			}
			List<dbCikti> s = ciktiManager.GetAll().Where(c => c.Bolum.Id == tez[0].Bolum.Id).ToList();
			Console.WriteLine("Sozluk Uzunlugu " + sozluk.Count);
			if (s.Count == 0)
			{
				ciktiManager.Add(new dbCikti() { CiktiKelimeler = sonMetin, Bolum = tez[0].Bolum });
			}
			else
			{
				//BURAYA CIKTIMANAGER UPDATE METODU GELECEK.
			}
			
		}

		public void BaslikKelimelerAyarla(List<dbTez> list)
		{

			string islenecekKelimeler = "";
			Metin metin;
			string sonkelime = "";
			foreach (var item in list)
			{
				islenecekKelimeler = item.TezAdi;
				islenecekKelimeler = islenecekKelimeler.ToLower();
				islenecekKelimeler = islenecekKelimeler.Replace("ve", "");
				islenecekKelimeler = islenecekKelimeler.Replace("ile", "");
				metin = new Metin(islenecekKelimeler);
				foreach (var sozluk in metin.MetinKelimeler())
				{
					sonkelime += sozluk + "|";
				}
				item.BaslikKelime = sonkelime;
				tezManager.Update(item);
				sonkelime = "";
			}

		}

		public void OzetKelimelerAyarla(List<dbTez> list)
		{

			string islenecekKelimeler = "";
			Metin metin;
			Dictionary<string, int> sozluk;

			string kelimeler = ciktiManager.GetAll().Where(c=>c.Bolum.Id==list[0].Bolum.Id).FirstOrDefault().CiktiKelimeler;
			string[] sonKelimeler = kelimeler.Split('|');
			foreach (var item in list)
			{

				metin = new Metin(item.TezOzet);
				sozluk = metin.SozlukGetir();

				Console.WriteLine("sozluk +" + sozluk.Count);

				foreach (var sozlukitem in sozluk)
				{
					for (int i = 0; i < sonKelimeler.Length; i++)
					{
						if (sonKelimeler[i] == sozlukitem.Key)
						{
							islenecekKelimeler += sonKelimeler[i] + "|";
						}
					}
				}

				//Console.WriteLine(islenecekKelimeler);
				item.OzetKelime = islenecekKelimeler;
				tezManager.Update(item);
				islenecekKelimeler = "";
				//Console.ReadLine();
			}

		}
		public void KeywordKelimelerAyarla(List<dbTez> list)
		{

			string islenecekKelimeler = "";

			foreach (var item in list)
			{
				islenecekKelimeler = item.Keywords;
				if (islenecekKelimeler == null)
				{
					islenecekKelimeler = "|";
				}

				islenecekKelimeler = islenecekKelimeler.ToLower();
				islenecekKelimeler = islenecekKelimeler.Replace(", ", "|");

				islenecekKelimeler = islenecekKelimeler.Replace(",", "|");

				item.KeywordsKelime = islenecekKelimeler;
				tezManager.Update(item);

				Console.WriteLine(islenecekKelimeler);
			}

		}

		public void YeniKeywordsAyarla(List<dbTez> list)
		{
			string[] kelimeler;
			string islemMetin = "";
			Dictionary<string, int> sozluk = new Dictionary<string, int>();
			foreach (dbTez tez in list)
			{
				tez.KeywordsKelime = tez.KeywordsKelime.Replace(System.Environment.NewLine, " ");
				tez.KeywordsKelime = tez.KeywordsKelime.Replace("(", "");
				tez.KeywordsKelime = tez.KeywordsKelime.Replace(")", "");
				tez.KeywordsKelime = tez.KeywordsKelime.Replace(" ", "|");
				kelimeler = tez.KeywordsKelime.Split('|');
				for (int i = 0; i < kelimeler.Length; i++)
				{
					if (sozluk.ContainsKey(kelimeler[i]))
					{

					}
					else
					{
						sozluk.Add(kelimeler[i], 0);
					}
				}
				
				for (int i = 0; i < sozluk.Keys.ToList().Count; i++)
				{
					islemMetin += sozluk.Keys.ToList()[i] + "|";

				}
				tez.KeywordsKelime = islemMetin;
				tezManager.Update(tez);
				islemMetin = "";

				sozluk.Clear();
			}
		}
	}
}

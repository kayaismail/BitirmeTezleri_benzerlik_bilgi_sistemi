using MetinAnalizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.BLL.Concrete;
using Tez.DAL.Concrete.EntityFramework;
using Tez.Entities;

namespace Islemler
{
	class KelimeIslemleri
	{
		TezManager tezManager;
		CiktiManager ciktiManager;
		public KelimeIslemleri()
		{
			ciktiManager = new CiktiManager(new EfCiktiDal());
			tezManager = new TezManager(new EfTezDal());
		}

		public void CiktiKelimelerAyarla()
		{

			List<dbTez> tez = tezManager.GetAll().ToList();

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

			Console.WriteLine("Sozluk Uzunlugu " + sozluk.Count);
			ciktiManager.Add(new dbCikti() { Id = 0, CiktiKelimeler = sonMetin });
		}

		public void BaslikKelimelerAyarla()
		{

			List<dbTez> list = tezManager.GetAll().ToList();
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
				//Console.ReadLine();

			}


		}

		public void OzetKelimelerAyarla()
		{

			List<dbTez> list = tezManager.GetAll().ToList();
			string islenecekKelimeler = "";
			Metin metin;
			Dictionary<string, int> sozluk;

			string kelimeler = ciktiManager.Get(4).CiktiKelimeler;
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
		public void KeywordKelimelerAyarla()
		{

			List<dbTez> list = tezManager.GetAll().ToList();
			string islenecekKelimeler = "";

			foreach (var item in list)
			{
				islenecekKelimeler = item.Keywords;
				if (islenecekKelimeler == null)
				{
					islenecekKelimeler = " | ";
				}

				islenecekKelimeler = islenecekKelimeler.ToLower();
				islenecekKelimeler = islenecekKelimeler.Replace(", ", "|");

				islenecekKelimeler = islenecekKelimeler.Replace(",", "|");

				item.KeywordsKelime = islenecekKelimeler;
				tezManager.Update(item);

				Console.WriteLine(islenecekKelimeler);
			}

		}


	}
}

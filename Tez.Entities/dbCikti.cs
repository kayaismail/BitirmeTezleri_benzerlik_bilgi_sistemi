using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tez.Entities
{
	public class dbCikti
	{
		public int Id { get; set; }
		public string CiktiKelimeler { get; set; }
		public virtual dbBolum Bolum { get; set; }
	}
}

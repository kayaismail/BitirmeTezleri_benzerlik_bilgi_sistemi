using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tez.Entities
{
	public class dbProje
	{
		public int Id { get; set; }
		public string ProjeAd { get; set; }
		public string ProjeIcerik { get; set; }
		public virtual dbDanisman Danisman { get; set; }

	}
}

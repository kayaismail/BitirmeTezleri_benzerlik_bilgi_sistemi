using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tez.Entities
{
	public class dbTezFikir
	{
		public int Id { get; set; }
		public int DanismanId { get; set; }
		public virtual dbDanisman Danisman { get; set; }
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string FikirAd { get; set; }
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string FikirIcerik { get; set; }
		public virtual dbOgrenci Gonderen { get; set; }
		public string FikirYorum { get; set; }
		public string TezFikirDurumu { get; set; }

	}
}

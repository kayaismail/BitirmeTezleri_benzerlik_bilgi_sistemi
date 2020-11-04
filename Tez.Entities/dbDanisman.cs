using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tez.Entities
{
	public class dbDanisman
	{
		public int Id { get; set; }
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string DanismanAd { get; set; }
		[DataType(DataType.EmailAddress)]
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string DanismanMail { get; set; }
		public string DanismanSifre { get; set; }

		public virtual System.Collections.Generic.List<dbTezFikir> TezFikirleri { get; set; }
		public virtual System.Collections.Generic.List<dbProje> DanismanProjeleri { get; set; }

		public int DanismanKontenjan { get; set; }

		public virtual dbBolum DanismanBolumu { get; set; }

	
	}
}

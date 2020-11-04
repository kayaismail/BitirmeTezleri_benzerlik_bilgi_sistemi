using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tez.Entities;

namespace Tez.WebUI.Models
{
	public class TezFikirDanisman
	{
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public dbTezFikir tezFikir { get; set; }
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public virtual List<dbDanisman> dbDanismen { get; set; }
		public string SecilenDanismanId { get; set; }

	}
}
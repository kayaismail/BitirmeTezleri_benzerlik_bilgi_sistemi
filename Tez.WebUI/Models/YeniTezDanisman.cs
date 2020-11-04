using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tez.Entities;

namespace Tez.WebUI.Models
{
	public class YeniTezDanisman
	{

		public dbTez tez { get; set; }
		public List<dbDanisman> Danismanlar { get; set; }
		public int SecilenDanismanId { get; set; }
	}
}

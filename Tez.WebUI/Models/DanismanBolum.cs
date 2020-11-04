using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tez.Entities;

namespace Tez.WebUI.Models
{
    public class DanismanBolum
    {

		public dbDanisman dbDanisman{ get; set; }
		[Required(AllowEmptyStrings = true)]
		public List<dbBolum> dbBolums { get; set; }
		public string SecilenBolumId { get; set; }
	}
}
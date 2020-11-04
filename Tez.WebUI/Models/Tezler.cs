using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tez.Entities;

namespace Tez.WebUI.Models
{
	public class Tezler
	{
		public List<dbTez> tezs { get; internal set; }
		public PagingInfo PagingInfo { get; internal set; }
		public Dictionary<dbTez,float> TezBenzerlikSozluk { get; set; }
	}
}
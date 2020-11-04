using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tez.Entities
{
    public class dbTez
    {
        public int Id { get; set; }
        public string TezAdi { get; set; }
        public string TezOzet { get; set; }
        public string Keywords { get; set; }
        public string Danisman { get; set; }
        public string TezGerceklestirenler { get; set; }
        public string YilDonem { get; set; }
        public string BaslikKelime { get; set; }
        public string OzetKelime { get; set; }
        public string KeywordsKelime { get; set; }
        public virtual dbBolum Bolum { get; set; }


    }
}

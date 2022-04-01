using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque1
{
    public class DtoProduto2
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string peso { get; set; }

    }
}

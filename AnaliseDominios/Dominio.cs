using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseDominios
{
    public class Dominio
    {
        public string dominio { get; set; }
        public string documento { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime ultima_atualizacao { get; set; }
        public string ticket { get; set; }
    }
}

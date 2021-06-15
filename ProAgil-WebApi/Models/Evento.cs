using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Model
{
    public class Evento
    {
        public int Eventoid { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QntdPessoas { get; set; }
        public string Lote { get; set; }
        public string imageUrl { get; set; }
    }
}

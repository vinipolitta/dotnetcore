﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAgil.Domain.Models;

namespace ProAgil.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Tema { get; set; }
        public int QntdPessoas { get; set; }
        public string ImagemURL { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Lote { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedeSociais { get; set; }
        public List<PalestranteEvento> PalestranteEventos { get; set; }

    }
}

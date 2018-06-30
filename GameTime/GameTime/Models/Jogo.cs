﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTime.Models
{
    [Table("Jogos")]
    public class Jogo
    {
        public Jogo()
        {
            Listas = new HashSet<Lista>();
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Capa { get; set; }
        public string Editora { get; set; }
        //public DateTime DataLancamento { get; set; }

        //[Column(Order = 0),ForeignKey("Estado")]
        //public int EstadoJogo { get; set; }
        //public virtual EstadoJogo Estado { get; set; }

        [Column(Order = 1),ForeignKey("Genero")]
        public int GeneroJogo { get; set; }
        public virtual Genero Genero { get; set; }

        public virtual ICollection<Lista> Listas { get; set; }
    }
}
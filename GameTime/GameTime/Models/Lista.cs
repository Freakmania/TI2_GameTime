using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTime.Models
{
    [Table("ListaJogos")]
    public class Lista
    {
        [Key, Column(Order = 0), ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }
        public virtual Utilizador Utilizador { get; set; }

        [Key,Column(Order =1),ForeignKey("Jogo")]
        public int JogoFK { get; set; }
        public virtual Jogo Jogo { get; set; }

        [Column(Order = 2), ForeignKey("EstadoJogador")]
        public int EstadoJogadorFK { get; set; }
        public virtual EstadoJogador EstadoJogador { get; set; }
    }
}
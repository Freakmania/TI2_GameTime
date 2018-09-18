using System;
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
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        public string Capa { get; set; }
        [Required]
        public string Editora { get; set; }
        //public DateTime DataLancamento { get; set; }

        [Column(Order = 0),ForeignKey("EstadoJogo")]
        public int EstadoJogoFK { get; set; }
        public virtual EstadoJogo EstadoJogo { get; set; }

        [Column(Order = 1),ForeignKey("Genero")]
        public int GeneroJogo { get; set; }
        public virtual Genero Genero { get; set; }

        public virtual ICollection<Lista> Listas { get; set; }
    }
}
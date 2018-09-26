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

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is a required field")]
        public string Nome { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is a required field")]
        public string Descricao { get; set; }

        [Display(Name = "Cover")]
        public string Capa { get; set; }

        [Display(Name = "Publisher")]
        [Required(ErrorMessage = "{0} is a required field")]
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
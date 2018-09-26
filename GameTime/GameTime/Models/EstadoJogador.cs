using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTime.Models
{
    [Table("EstadoJogadores")]
    public class EstadoJogador
    {
        [Key]
        public int Id { get; set; }

        //nome do estado em que o jogador se encontra, a jogar, por jogar, já jogado, etc..
        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is a required field")]
        public string Nome { get; set; }
    }
}
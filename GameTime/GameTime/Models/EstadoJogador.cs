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
        public string Nome { get; set; }
    }
}
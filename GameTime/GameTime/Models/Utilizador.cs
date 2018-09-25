using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTime.Models
{
    [Table("Utilizadores")]
    public class Utilizador
    {
        public Utilizador()
        {
            Listas = new HashSet<Lista>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string NomeUtilizador { get; set; }
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Nome { get; set; }
        public string Foto { get; set; }

        public virtual ICollection<Lista> Listas { get; set; }
    }
}
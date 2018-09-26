using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTime.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is a required field")]
        public string Nome { get; set; }
    }
}
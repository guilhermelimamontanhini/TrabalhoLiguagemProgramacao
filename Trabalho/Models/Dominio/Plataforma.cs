using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.Dominio
{
    public class Plataforma
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Nome da Plataforma")]
        public string nome { get; set; }
        public ICollection<Jogo> jogos { get; set; }
        public ICollection<Usuario> usuarios { get; set; }

    }
}

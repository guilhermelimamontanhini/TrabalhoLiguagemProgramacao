using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.Dominio
{
    public class Usuario
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Nome do Usuário")]
        [Required(ErrorMessage = "Campo Nome do Usuário é obrigatório")]
        public string nome { get; set; }

        [ForeignKey("Plataforma")]
        public int plataformaID { get; set; }
        [Display(Name = "Plataforma")]
        public Plataforma plataforma { get; set; }

        [Display(Name = "E-mail do Usuário")]
        [Required(ErrorMessage = "Campo E-mail do Usuário é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
        public string email { get; set; }

        public ICollection<Jogo> jogos { get; set; }

        public ICollection<Plataforma> plataformas { get; set; }
    }
}

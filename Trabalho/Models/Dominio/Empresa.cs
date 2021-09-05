using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.Dominio
{
    public class Empresa
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Nome da Empresa")]
        [Required(ErrorMessage = "Campo Nome da Empresa é obrigatório")]
        public string nome { get; set; }

        [Display(Name = "Data de Fundação")]
        [Required(ErrorMessage = "Campo Data de Fundação é obrigatório")]
        public DateTime dataFundacao { get; set; }

        [Display(Name = "Local da Sede")]
        [Required(ErrorMessage = "Campo Local da Sede é obrigatório")]
        public string sede { get; set; }
        public ICollection<Jogo> jogos { get; set; }
    }
}

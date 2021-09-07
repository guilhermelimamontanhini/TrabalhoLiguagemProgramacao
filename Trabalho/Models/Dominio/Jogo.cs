using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.Dominio
{
    public class Jogo
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [ForeignKey("Usuario")]
        public int usuarioID { get; set; }
        [Display(Name = "Usuário")]
        public Usuario usuario { get; set; }

        [ForeignKey("Plataforma")]
        public int plataformaID { get; set; }
        [Display(Name = "Plataforma")]
        public Plataforma plataforma { get; set; }

        [Display(Name = "Nome do Jogo")]
        [Required(ErrorMessage = "Campo Nome do Jogo é obrigatório")]
        public string nome { get; set; }

        [Display(Name = "Preço do Jogo")]
        [Required(ErrorMessage = "Campo Preço do Jogo é obrigatório")]
        public float preco { get; set; }

        [Display(Name = "Gênero do Jogo")]
        [Required(ErrorMessage = "Campo Gênero do Jogo é obrigatório")]
        public string genero { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models.Dominio;
using Trabalho.Models.Mapeamento;

namespace Trabalho.Models
{
    public class Contexto : DbContext
    {/*Vincular o modelo de classes com o de banco*/

        /*
         Injeta os proprios varios da Classe nela mesma
         Passa o conhecimento de DbContext para o Contexto, e o mesmo aprende a usar os seus metodos
         */
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        /*Dominio da Aplicação*/
        /* DbSet => Vincula as classes com as tabelas do banco */
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Usuario> Usuasio { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new JogoMap());
            builder.ApplyConfiguration(new UsuarioMap());
        }

    }
}

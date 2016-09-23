using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Usuario.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext() : base("Usuario")
        {
        }
        public DbSet<Usuario.Models.Usuario> Usuarios { get; set; }
        public DbSet<Usuario.Models.Grupo> Grupos { get; set; }
        public DbSet<Usuario.Models.Programa> Programas { get; set; }
        public DbSet<Usuario.Models.UsuarioGrupo> UsuarioGrupos { get; set; }

    }
}
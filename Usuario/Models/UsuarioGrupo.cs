using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Usuario.Models
{
    public class UsuarioGrupo
    {  
        [Column(Order = 0), Key, ForeignKey("Usuario")]
        public int idUsuario { get; set; }

        [Column(Order = 1), Key, ForeignKey("Grupo")]
        public int idGrupo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
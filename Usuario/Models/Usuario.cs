using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usuario.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string password { get; set; }

    }
}
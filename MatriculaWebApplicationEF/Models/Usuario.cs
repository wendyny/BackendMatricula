using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.Models
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string PasswordUsuario { get; set; }
        public bool isActive { get; set; }
    }
}

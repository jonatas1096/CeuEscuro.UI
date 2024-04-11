using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set;}
        public string Senha { get; set;}
        public DateTime DataNascUsuario { get; set;}
        public string TipoUsuario_Id { get; set; }
    }
}

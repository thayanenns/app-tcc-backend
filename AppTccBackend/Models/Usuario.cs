using AppTccBackend.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AppTccBackend.Models
{
    public abstract class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
        public TipoUsuario Tipo { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

        public Usuario(){}

    }
}

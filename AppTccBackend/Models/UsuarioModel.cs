using System.ComponentModel.DataAnnotations;

namespace AppTccBackend.Models
{
    //abstract
    public class UsuarioModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
        // public abstract string Tipo { get; set;}

        /*public UsuarioModel(Guid id, string email, string senha)
        {
            Id = Guid.NewGuid();
            Email = email;
            Senha = senha;
        }*/
        public UsuarioModel() { }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
     }

}

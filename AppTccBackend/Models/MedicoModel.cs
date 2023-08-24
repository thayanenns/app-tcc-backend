using System.ComponentModel.DataAnnotations;

namespace AppTccBackend.Models
{
    public class MedicoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Crm { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        //public string Tipo { get; set; }

        public string Tipo => "Medico";
        public  ICollection<PacienteModel>? Pacientes { get; set;}
        

    }
}

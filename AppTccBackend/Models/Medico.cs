using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTccBackend.Models
{
    public class Medico: Usuario
    {
        public string Crm { get; set; }
        [InverseProperty("Medico")]

        public ICollection<Paciente>? Pacientes { get; set;}

        

    }
}

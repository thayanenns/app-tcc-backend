using AppTccBackend.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTccBackend.Models
{
    public class Paciente: Usuario
    {
        public Medico? Medico { get; set; }
        [ForeignKey("Medico")]
        public Guid? MedicoId { get; set; }
        public ICollection<Medicao>? Medicoes { get; set; } 

        public TipoDiabetes TipoDiabetes { get; set; }
    }
}

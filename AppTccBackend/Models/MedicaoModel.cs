using System.ComponentModel.DataAnnotations;

namespace AppTccBackend.Models
{
    public class MedicaoModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataMedicao { get; set; }
        public int Glicemia { get; set; }
        public int PressaoSistolica { get; set; }
        public int PressaoDiastolica { get; set; }
        public Boolean EmJejum { get; set; }
        public PacienteModel Paciente { get; set; }
        public int PacienteId { get; set; }
      
        // public Guid UsuarioId { get; set; }

        /* public MedicaoModel(int id, int glicemia, int pressaoSistolica, int pressaoDiastolica, Boolean emJejum) 
         {
             MedicaoId = id;
             DataMedicao = DateTime.Now;
             Glicemia = glicemia;
             PressaoSistolica = pressaoSistolica;
             PressaoDiastolica = pressaoDiastolica;
             EmJejum = emJejum;

         }
        */

    }
}

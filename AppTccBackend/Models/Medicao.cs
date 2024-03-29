﻿using System.ComponentModel.DataAnnotations;

namespace AppTccBackend.Models
{
    public class Medicao
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataMedicao { get; set; }
        public int Batimentos { get; set; }
        public int PressaoSistolica { get; set; }
        public int PressaoDiastolica { get; set; }
        public int Glicemia { get; set; }
        public bool EmJejum { get; set; }

        public int Peso { get; set; }
        public int Altura { get; set; }

        public Guid PacienteId { get; set; }
        public Paciente? Paciente { get; set; } 

    }
}

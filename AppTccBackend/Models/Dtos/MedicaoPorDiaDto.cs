namespace AppTccBackend.Models.Dtos
{
    public class MedicaoPorDiaDto
    {

        public DateTime DataDia { get; set; }
        public List<Medicao> Medicoes { get; set; }
    }
}

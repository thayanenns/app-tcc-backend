namespace AppTccBackend.Models.Dtos
{
    public class UsuarioDetalhesDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid? MedicoId { get; set; }
    }

}

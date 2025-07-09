
namespace Anexa.Application.DTOs
{
    public class CursoDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco {  get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid InstrutorId { get; set; }
        public string NomeInstrutor { get; set; } = string.Empty;

    }
}

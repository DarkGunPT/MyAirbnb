namespace TPPweb2122.Models
{
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }
        public int PontuacaoAvaliacao { get; set; }
        public string DescricaoAvaliacao { get; set; }
        public int? ImovelId { get; set; }
        public virtual Imovel Imovel { get; set; }
        public int? clienteId { get; set; }
        public virtual Cliente cliente { get; set; }
    }
}

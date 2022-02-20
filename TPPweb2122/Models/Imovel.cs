using System;

namespace TPPweb2122.Models
{
    public class Imovel
    {
        public int ImovelId { get; set; }
        public string NomeAlojamento { get; set; }
        public string Localizacao { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFinal { get; set; }
        public int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int? gestorId { get; set; }
        public virtual Gestor Gestor { get; set; }
    }
}

using System.Collections.Generic;

namespace TPPweb2122.Models
{
    public class Categoria
    {
        public Categoria(){
            Imoveis= new HashSet<Imovel>();    
        }
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }
        public ICollection<Imovel> Imoveis { get; set; }
    }
}

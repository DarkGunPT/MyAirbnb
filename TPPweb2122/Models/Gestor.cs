using System.Collections.Generic;

namespace TPPweb2122.Models
{
    public class Gestor : Utilizador
    {
        public Gestor()
        {
            Funcionarios = new HashSet<Funcionario>();
            Imoveis = new HashSet<Imovel>();
        }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<Imovel> Imoveis { get; set; }
    }
}

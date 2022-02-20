using System.Collections.Generic;

namespace TPPweb2122.Models
{
    public class Cliente : Utilizador
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
            Avaliacoes = new HashSet<Avaliacao>();
        }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}

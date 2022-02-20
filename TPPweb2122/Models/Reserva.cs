using System;
using System.ComponentModel.DataAnnotations;

namespace TPPweb2122.Models
{
    public class Reserva
    {
        [Display(Name = "ID Reserva")]
        public int ReservaId { get; set; }
        [Display(Name = "Data Entrada")]
        public DateTime dataEntrada { get; set; }
        [Display(Name = "Data Saída")]
        public DateTime dataSaida { get; set; }

        [Display(Name = "ID Imóvel")]
        public int? ImovelId { get; set; }
        public virtual Imovel Imovel {get; set; }
        [Display(Name = "ID Cliente")]
        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public bool Confirmacao { get; set; }

    }
}

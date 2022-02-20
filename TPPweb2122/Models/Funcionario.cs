namespace TPPweb2122.Models
{
    public class Funcionario : Utilizador
    {
        public int? gestorId { get; set; }
        public virtual Gestor Gestor { get; set; }
    }
}

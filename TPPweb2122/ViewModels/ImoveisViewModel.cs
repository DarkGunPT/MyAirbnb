using System.Linq;
using TPPweb2122.Models;
using X.PagedList;

namespace TPPweb2122.ViewModels
{
    public class ImoveisViewModel
    {
        public IPagedList<Imovel> Imoveis { get; set; }

        public void paginacao(IQueryable<Imovel> imoveis,int page,int nreg)
        {
            Imoveis = imoveis.ToPagedList(page, nreg);
            return;
        }
    }
    public class GestorViewModel
    {
        public IPagedList<Gestor> Gestores { get; set; }

        public void paginacao(IQueryable<Gestor> gestores, int page, int nreg)
        {
            Gestores = gestores.ToPagedList(page, nreg);
            return;
        }
    }
    public class FuncionariosViewModel
    {
        public IPagedList<Funcionario> Funcionarios { get; set; }

        public void paginacao(IQueryable<Funcionario> funcionarios, int page, int nreg)
        {
            Funcionarios = funcionarios.ToPagedList(page, nreg);
            return;
        }
    }

    public class ReservasViewModel
    {
        public IPagedList<Reserva> Reservas { get; set; }

        public void paginacao(IQueryable<Reserva> reservas, int page, int nreg)
        {
            Reservas = reservas.ToPagedList(page, nreg);
            return;
        }
    }


        public class HistoricoViewModelo
        {
            public IPagedList<Avaliacao> Avaliacoes { get; set; }

            public void paginacao(IQueryable<Avaliacao> reservas, int page, int nreg)
            {
                Avaliacoes = reservas.ToPagedList(page, nreg);
                return;
            }
        }

    }

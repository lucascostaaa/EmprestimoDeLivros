using System;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        private ControladorRevista controladorRevista;
        private ControladorAmigo controladorAmigo;


        public ControladorEmprestimo(ControladorAmigo ctrlAmigo, ControladorRevista ctrlRevista)
        {
            controladorAmigo = ctrlAmigo;
            controladorRevista = ctrlRevista;
        }
  
        public string RegistrarEmprestimo(int id, int idAmigoEmprestimo, int idRevistaEmprestimo, DateTime dataEmprestimo)
        {
            Emprestimo emprestimo;

            int posicao;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.amiguinho = controladorAmigo.SelecionarAmigoPorId(idAmigoEmprestimo);
            emprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo);
            emprestimo.dataEmprestimo = dataEmprestimo;

            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
            {
                registros[posicao] = emprestimo;
            }
              
            return resultadoValidacao;
        }
        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            Emprestimo[] emprestimoAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimoAux, emprestimoAux.Length);

            return emprestimoAux;
        }
    }
}

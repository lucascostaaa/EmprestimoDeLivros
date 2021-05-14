using System;
using EmprestimoDeLivros.ConsoleApp.Controladores;

namespace EmprestimoDeLivros.ConsoleApp.Telas
{
    public class TelaPrincipal: TelaBase
    {
        private readonly ControladorRevista controladorRevista;
        private readonly ControladorCaixa controladorCaixa;
        private readonly ControladorAmigo controladorAmigo;
        private readonly ControladorEmprestimo controladorEmprestimo;

        public TelaPrincipal(ControladorCaixa ctlrCaixa,ControladorRevista controlador, ControladorAmigo ctrlAmigo, ControladorEmprestimo ctrlEmprestimo) : base("Tela Principal")
        {
            controladorCaixa = ctlrCaixa;
            controladorRevista = controlador;
            controladorAmigo = ctrlAmigo;
            controladorEmprestimo = ctrlEmprestimo;
        }
        public ICadastravel ObterOpcao()
        {
            ConfigurarTela("Escolha uma opção: ");

            ICadastravel telaSelecionada = null;
            string opcao;
            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para o Cadastro de Caixa");
                Console.WriteLine("Digite 2 para o Cadastro de Revista");
                Console.WriteLine("Digite 3 para o Cadastro de Amigo");
                Console.WriteLine("Digite 4 para o Cadastro de Emprestimo");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    telaSelecionada = new TelaCaixa(controladorCaixa);
                }
        
                else if (opcao == "2") 
                {
                    telaSelecionada = new TelaRevista(controladorCaixa, controladorRevista);
                }

                else if (opcao == "3") 
                {
                    telaSelecionada = new TelaAmigo(controladorAmigo);
                }
                else if (opcao == "4")
                {
                    telaSelecionada = new TelaEmprestimo(controladorRevista, controladorAmigo, controladorEmprestimo);
                }

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else
                return false;
        }

    }
}

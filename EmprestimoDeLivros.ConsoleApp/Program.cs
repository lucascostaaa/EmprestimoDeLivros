using System;
using EmprestimoDeLivros.ConsoleApp.Controladores;
using EmprestimoDeLivros.ConsoleApp.Telas;

namespace EmprestimoDeLivros.ConsoleApp
{

    #region Requisito 01 [FEITO]
    //Cada caixa tem uma cor, uma etiqueta e um número.
    #endregion

    #region Requisito 02 [FEITO]
    //Para cada revista, deverá ser cadastrado: o tipo de coleção, o número da edição, o ano da revista e a caixa onde está guardada.
    #endregion

    #region REQUISITO 03 [FEITO]
    //O cadastro do amiguinho consiste de: nome, nome do responsável, telefone e de onde é o amigo.
    #endregion

    #region REQUISITO 05 [FEITO/FALTOU DATA DEVOLUÇÃO]
    //Para cada empréstimo cadastram-se: o amiguinho que pegou a revista, qual foi a revista, a data do empréstimo e a data de devolução.
    #endregion

    #region REQUISITO 06 [NAO FEITO]
    //Mensalmente Gustavo verifica os empréstimos realizados no mês e diariamente os empréstimos que estão em aberto.
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            ControladorCaixa ctrlCaixa = new ControladorCaixa();

            ControladorRevista ctrlRevista = new ControladorRevista(ctrlCaixa);

            ControladorAmigo ctrlAmigo = new ControladorAmigo();

            ControladorEmprestimo crtlEmprestimo = new ControladorEmprestimo(ctrlAmigo,ctrlRevista);

            TelaPrincipal telaPrincipal = new TelaPrincipal(ctrlCaixa, ctrlRevista, ctrlAmigo, crtlEmprestimo);

            while (true)
            {
                ICadastravel telaSelecionada = telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                if(telaSelecionada is TelaBase)
                Console.WriteLine(((TelaBase)telaSelecionada).Titulo); Console.WriteLine();

                string opcao = telaSelecionada.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (opcao == "1")
                    telaSelecionada.InserirNovoRegistro();

                else if (opcao == "2")           
                {
                    telaSelecionada.VisualizarRegistros();
                    Console.ReadLine();
                }
                else if (opcao == "3") 
                {
                    telaSelecionada.ExcluirRegistro();
                    Console.ReadLine();
                }

                else if (opcao == "4") { }
                
                Console.Clear();
            }
        }
    }
}

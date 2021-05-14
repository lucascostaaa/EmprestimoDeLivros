using System;
using EmprestimoDeLivros.ConsoleApp.Controladores;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Telas
{
    public class TelaRevista : TelaBase, ICadastravel
    {
        private ControladorRevista controladorRevista;
        private ControladorCaixa controladorCaixa;

        public TelaRevista(ControladorCaixa crtlCaixa, ControladorRevista controlador)
            : base("Cadastro de Revista")
        {
            controladorRevista = controlador;
            controladorCaixa = crtlCaixa;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova REVISTA...");

            bool conseguiuGravar = GravarRevista(0);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir a caixa", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }
        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Revista...");

            MontarCabecalhoTabela();

            Revista[] revistas = controladorRevista.SelecionarTodosRevistas();

            if (revistas.Length == 0)
            {
                ApresentarMensagem("Nenhuma revista registrado!", TipoMensagem.Atencao);
                return;
            }

            foreach (Revista revista in revistas)
            {
                Console.WriteLine("{0,-10} | {1,-15} | {2,-15} | {3,-45} | {4,-15}",
                    revista.id, revista.caixa.cor, revista.colecao, revista.nEdicao, revista.anoRevista);
            }
        }
        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma Revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o ID da Revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Revista excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir essa Revista", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }
        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo registro");
            Console.WriteLine("Digite 2 para visualizar registros"); 
            Console.WriteLine("Digite 3 para Excluir registros");
            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        #region Privado
        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Id", "Caixa", "Coleção", "Numero Edição", "Ano de Publicação");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        private bool GravarRevista(int idRevistaSelecionada)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            VisualizarCaixa();

            Console.Write("Digite o Id da caixa aonde pretende arrumar a Revista: ");
            int idCaixaRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a Coleção da revista: ");
            string colecao = Console.ReadLine();

            Console.Write("Informe o numero de Edição da revista: ");
            int etiquetaCaixa = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de publicação da revista: ");
            string anoRevista = Console.ReadLine();

            resultadoValidacao = controladorRevista.RegistrarRevista(
                idRevistaSelecionada, idCaixaRevista, colecao, etiquetaCaixa, anoRevista);

            if (resultadoValidacao != "REVISTA_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        private void VisualizarCaixa()
        {
            Console.WriteLine();
            Caixa[] caixa = controladorCaixa.SelecionarTodosCaixa();

            Console.WriteLine("{0,-10} | {1,-30}", "Id", "Caixa");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            foreach (var e in caixa)
            {
                Console.WriteLine("{0,-10} | {1,-30}", e.id, e.cor);
            }
            Console.WriteLine();
        }

        #endregion
    }
}

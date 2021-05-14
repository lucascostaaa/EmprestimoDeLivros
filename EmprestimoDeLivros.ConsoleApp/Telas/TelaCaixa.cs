using System;
using EmprestimoDeLivros.ConsoleApp.Controladores;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Telas
{
    public class TelaCaixa : TelaBase, ICadastravel
    {
        private ControladorCaixa controladorCaixa;

        public TelaCaixa(ControladorCaixa controlador)
            : base("Cadastro de Caixa")
        {
            controladorCaixa = controlador;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um nova caixa...");

            bool conseguiuGravar = GravarCaixa(0);

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
            ConfigurarTela("Visualizando Caixa...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] equipamentos = controladorCaixa.SelecionarTodosCaixa();

            if (equipamentos.Length == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   equipamentos[i].id, equipamentos[i].cor, equipamentos[i].etiquetaCaixa);
            }
        }
        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma Caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o ID da Caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Caixa excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir Caixa", TipoMensagem.Erro);
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
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Cor", "Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        private bool GravarCaixa(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Informe a etiqueta da caixa: ");
            string etiquetaCaixa = Console.ReadLine();

            resultadoValidacao = controladorCaixa.RegistrarCaixa(
                id, cor, etiquetaCaixa);

            if (resultadoValidacao != "CAIXA_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
        #endregion
    }
}

using System;
using EmprestimoDeLivros.ConsoleApp.Controladores;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Telas
{
    public class TelaEmprestimo : TelaBase, ICadastravel
    {
        private ControladorEmprestimo ControladorEmprestimo;
        private ControladorRevista controladorRevista;
        private ControladorAmigo controladorAmigo;


        public TelaEmprestimo(ControladorRevista controlador, ControladorAmigo crtlAmigo, ControladorEmprestimo crtlEmprestimo)
            : base("Cadastro de Emprestimo")
        {
            controladorAmigo = crtlAmigo;
            controladorRevista = controlador;
            ControladorEmprestimo = crtlEmprestimo;
      
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma novo Emprestimo...");

            bool conseguiuGravar = GravarEmprestimo(0);

            if (conseguiuGravar)
            {
                ApresentarMensagem("Emprestimo cadastrado com sucesso", TipoMensagem.Sucesso);
            
            }
            else
            {
                ApresentarMensagem("Falha ao tentar cadastrar emprestimo", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }
        public void VisualizarRevista()
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
            Console.WriteLine();
        }
        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Empestimos...");

            MontarCabecalhoTabela();

            Emprestimo[] emprestimos = ControladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimos.Length == 0)
            {
                ApresentarMensagem("Nenhum emprestimo cadastrado!", TipoMensagem.Atencao);
                return;
            }

            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine("{0,-10} | {1,-15} | {2,-15} | {3,-45}",
                    emprestimo.id, emprestimo.amiguinho.nome, emprestimo.revista.colecao, emprestimo.dataEmprestimo);
            }

        }
        public void ExcluirRegistro()
        {

        }
        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo registro"); 
            Console.WriteLine("Digite 2 para inserir novo registro");
            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        #region PRIVADO
        
        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Id", "Caixa", "Coleção", "Numero Edição", "Ano de Publicação");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        private bool GravarEmprestimo(int idEmprestimoSelecionada)
        {

            VisualizarAmigo();

            Console.Write("Digite o Id do amigo: ");
            int idAmigoEmprestimo = Convert.ToInt32(Console.ReadLine());

            VisualizarRevista();

            Console.Write("Digite o id da revista: ");
            int idRevistaEmprestimo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe a data de Emprestimo: ");
            DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine());

   
            string resultadoValidacao = ControladorEmprestimo.RegistrarEmprestimo(
                idEmprestimoSelecionada, idAmigoEmprestimo, idRevistaEmprestimo, dataEmprestimo);

            bool conseguiuGravar = true;

            if (resultadoValidacao != "EMPRESTIMO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
        private void VisualizarAmigo()
        {
            Console.WriteLine();
            Amigo[] amigo = controladorAmigo.SelecionarTodosAmigos();

            Console.WriteLine("{0,-10} | {1,-30}", "Id", "Caixa");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            foreach (var e in amigo)
            {
                Console.WriteLine("{0,-10} | {1,-30}", e.id, e.nome);
            }
            Console.WriteLine();
        }
        #endregion
    }
}

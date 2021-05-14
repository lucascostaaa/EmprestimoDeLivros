using System;
using EmprestimoDeLivros.ConsoleApp.Controladores;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Telas
{
    public class TelaAmigo: TelaBase, ICadastravel
    {
        private ControladorAmigo controladorAmigo;

        public TelaAmigo(ControladorAmigo controlador)
           : base("Cadastro de Amigo")
        {
            controladorAmigo = controlador;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Cadastrando um novo Amigo...");

            bool conseguiuGravar = GravarAmigo(0);

            if (conseguiuGravar)
                ApresentarMensagem("Amigo cadastrado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar cadastrar o amigo", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Amigos...");

            string configuracaColunasTabela = "{0,-5} | {1,-5} | {2,-25} | {3,-10} | {4,-55}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amigo[] amigos = controladorAmigo.SelecionarTodosAmigos();

            if (amigos.Length == 0)
            {
                ApresentarMensagem("Nenhum amigo cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < amigos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   amigos[i].id, amigos[i].nome, amigos[i].nomeDoResponsável, amigos[i].telefone, amigos[i].endereco);
            }
        }
        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Amigo...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o ID do Amigo que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorAmigo.ExcluirAmigo(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Amigo excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir amigo", TipoMensagem.Erro);
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
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome","Responsavel","Telefone","Endereço");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        private bool GravarAmigo(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome do Amigo(a): ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do(a) Responsavel: ");
            string nomeDoResponsavel = Console.ReadLine();

            Console.Write("Digite o numero de telefone: ");
            string telefone = (Console.ReadLine());

            Console.Write("Digite o endereço em que mora: ");
            string endereco = Console.ReadLine();

            resultadoValidacao = controladorAmigo.RegistrarAmigo(
                id, nome, nomeDoResponsavel, telefone, endereco);

            if (resultadoValidacao != "AMIGO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
    }
}

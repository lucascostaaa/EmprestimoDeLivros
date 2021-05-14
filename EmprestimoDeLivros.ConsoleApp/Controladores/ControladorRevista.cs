using System;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Controladores
{
    public class ControladorRevista : ControladorBase
    {
        private ControladorCaixa controladorCaixa;

        public ControladorRevista(ControladorCaixa ctrlCaixa)
        {
            controladorCaixa = ctrlCaixa;
        }

        public string RegistrarRevista(int id, int idCaixaRevista, string colecao, int nEdicao, string anoRevista)
        {
            Revista revista;

            int posicao;

            if(id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else 
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.caixa = controladorCaixa.SelecionarCaixaPorId(idCaixaRevista);
            revista.colecao = colecao;
            revista.nEdicao = nEdicao;
            revista.anoRevista = anoRevista;

            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "REVISTA_VALIDO")
                registros[posicao] = revista;

            return resultadoValidacao;
        }

        public Revista[] SelecionarTodosRevistas()
        {
            Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }
    }
}

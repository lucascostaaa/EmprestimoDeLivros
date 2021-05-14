using System;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        public string RegistrarCaixa(int id, string cor, string etiquetaCaixa)
        {
            Caixa caixa = null;

            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }

            caixa.cor = cor;
            caixa.etiquetaCaixa = etiquetaCaixa;

            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CAIXA_VALIDO")
                registros[posicao] = caixa;

            return resultadoValidacao;

        }
        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }
        public Caixa[] SelecionarTodosCaixa()
        {
            Caixa[] caixasAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixasAux, caixasAux.Length);

            return caixasAux;
        }
        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }
    }
}

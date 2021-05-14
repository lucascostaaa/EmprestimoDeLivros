using System;

namespace EmprestimoDeLivros.ConsoleApp.Dominio
{
    public class Caixa
    {
        public int id;
        public string cor;
        public string etiquetaCaixa;

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public Caixa(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CAIXA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Caixa caixa = (Caixa)obj;

            if (id == caixa.id)
                return true;
            else
                return false;
        }

    }
}

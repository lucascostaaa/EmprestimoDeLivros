using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmprestimoDeLivros.ConsoleApp.Dominio
{
    public class Revista
    {
        public int id;
        public string colecao;
        public int nEdicao;
        public string anoRevista;
        public Caixa caixa;


        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }
        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(colecao))
                resultadoValidacao += "A campo Coleção é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
                return true;
            else
                return false;
        }
    }
}

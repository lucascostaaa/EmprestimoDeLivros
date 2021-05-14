using System;

namespace EmprestimoDeLivros.ConsoleApp.Dominio
{
    public class Amigo
    {
        public int id;
        public string nome;
        public string nomeDoResponsável;
        public string telefone;
        public string endereco;


        public Amigo()
        {
            id = GeradorId.GerarIdAmigo();
        }
        public Amigo(int idSelecionado)
        {
            id = idSelecionado;
        }
        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (string.IsNullOrEmpty(nomeDoResponsável))
                resultadoValidacao += "O campo Nome do responsavel é obrigatório \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo telefone é obrigatório \n";

            if (string.IsNullOrEmpty(endereco))
                resultadoValidacao += "O campo endereço é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "AMIGO_VALIDO";
        
            return resultadoValidacao;
        }
        public override bool Equals(object obj)
        {
            Amigo amigo = (Amigo)obj;

            if (id == amigo.id)
                return true;
            else
                return false;
        }


    }
}

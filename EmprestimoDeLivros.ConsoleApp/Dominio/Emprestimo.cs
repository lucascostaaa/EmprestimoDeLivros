using System;


namespace EmprestimoDeLivros.ConsoleApp.Dominio
{
    public class Emprestimo
    {
        public int id;
        public Amigo amiguinho;
        public Revista revista;
        public DateTime dataEmprestimo;


        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }
        public Emprestimo(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (dataEmprestimo > DateTime.Now)
                resultadoValidacao += "O campo Data de Emprestimo não pode ser no futuro \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;
        }
        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (id == emprestimo.id)
                return true;
            else
                return false;
        }

    }
}

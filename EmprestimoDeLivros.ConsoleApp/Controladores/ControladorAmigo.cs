using System;
using EmprestimoDeLivros.ConsoleApp.Dominio;

namespace EmprestimoDeLivros.ConsoleApp.Controladores
{
    public class ControladorAmigo : ControladorBase
    {
        public string RegistrarAmigo(int id, string nome, string nomeDoResponsavel, string telefone, string endereco)
        {
            Amigo amigo = null;

            int posicao;

            if (id == 0)
            {
                amigo = new Amigo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amigo(id));
                amigo = (Amigo)registros[posicao];
            }

            amigo.nome = nome;
            amigo.nomeDoResponsável = nomeDoResponsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            string resultadoValidacao = amigo.Validar();

            if (resultadoValidacao == "AMIGO_VALIDO")
                registros[posicao] = amigo;

            return resultadoValidacao;
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            return (Amigo)SelecionarRegistroPorId(new Amigo(id));
        }
        public Amigo[] SelecionarTodosAmigos()
        {
            Amigo[] amigoAux = new Amigo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amigoAux, amigoAux.Length);

            return amigoAux;
        }

        public bool ExcluirAmigo(int idSelecionado)
        {
            return ExcluirRegistro(new Amigo(idSelecionado));
        }

    }
}

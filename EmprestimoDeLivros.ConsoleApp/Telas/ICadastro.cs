using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoDeLivros.ConsoleApp.Telas
{
    public interface ICadastravel
    {
        void InserirNovoRegistro();

        void VisualizarRegistros();

        void ExcluirRegistro();

        string ObterOpcao();
    }
}

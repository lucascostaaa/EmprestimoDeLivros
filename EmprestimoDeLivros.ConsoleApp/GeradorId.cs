﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoDeLivros.ConsoleApp
{
    public class GeradorId
    {
        private static int idCaixa = 0;
        private static int idRevista = 0;
        private static int idAmigo = 0;
        private static int idEmprestimo = 0;


        public static int GerarIdCaixa()
        {
            return ++idCaixa;
        }

        public static int GerarIdRevista()
        {
            return ++idRevista;
        }
        public static int GerarIdAmigo()
        {
            return ++idAmigo;
        }
        public static int GerarIdEmprestimo()
        {
            return ++idEmprestimo;
        }

    }
}

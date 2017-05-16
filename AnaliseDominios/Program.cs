using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseDominios
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();
            var dominiosPorEstado = parser.ParseDominiosPorEstado();
            var dominiosPorInstituicao = parser.ParseDominiosPorInstituição();
            var dominiosPorAnoDeCadastro = parser.ParseDominiosPorAnoDeCadastro();
            var dominiosPorMesDeCadastro = parser.ParseDominiosPorMesDeCadastro();
            var dominiosPorAnoDeAtualizacao = parser.ParseDominiosPorAnoDeAtualizacao();
            var dominiosMesDeAtualizacao = parser.ParseDominiosPorMesDeAtualizacao();

            Console.WriteLine("Análise dos Domínios .gov.br registrados pelo Ministério do Planejamento");
            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");
            Console.WriteLine(string.Format("Total de domínios: {0}", parser.dominios.Count()));

            Console.WriteLine("Domínios por Estado:");
            MostrarResultados(dominiosPorEstado);
            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("Domínios por instituição:");
            MostrarResultados(dominiosPorInstituicao.Where(x => x.Value > 1));
            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("Domínios por ano de cadastro:");
            MostrarResultados(dominiosPorAnoDeCadastro);
            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("Domínios por mês de cadastro:");
            MostrarResultados(dominiosPorMesDeCadastro);
            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("Domínios por ano de atualização:");
            MostrarResultados(dominiosPorAnoDeAtualizacao);
            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("Domínios por mês de atualização:");
            MostrarResultados(dominiosMesDeAtualizacao);
            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.ReadKey();
        }

        public static void MostrarResultados(dynamic dicionario)
        {
            foreach (var kvp in dicionario)
            {
                Console.WriteLine(string.Format("{0} - {1}", kvp.Key, kvp.Value));
            }
        }
    }
}

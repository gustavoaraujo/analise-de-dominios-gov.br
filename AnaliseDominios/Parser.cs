using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseDominios
{
    public class Parser
    {
        public List<Dominio> dominios;

        public Parser()
        {
            this.dominios = new List<Dominio>();
            ParseDominios();
        }

        public void ParseDominios()
        {
            string caminho = Environment.CurrentDirectory + @"\Dominios_GovBR_basico.csv";
            var todasLinhas = System.IO.File.ReadAllLines(caminho, Encoding.UTF7).Skip(1).ToArray();
            
            foreach (var linha in todasLinhas)
            {
                var dados = linha.Split(';');

                var dominio = new Dominio();
                dominio.dominio = dados[0];
                dominio.documento = dados[1];
                dominio.nome = dados[2];
                dominio.uf = dados[3];
                dominio.cidade = dados[4];
                dominio.cep = dados[5];
                dominio.data_cadastro = DateTime.Parse(dados[6]);
                dominio.ultima_atualizacao = DateTime.Parse(dados[7]);
                dominio.ticket = dados[8];

                dominios.Add(dominio);
            }
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> ParseDominiosPorEstado()
        {
            var dicionario = new Dictionary<string, int>();

            var ufs = dominios.Select(i => i.uf).Distinct();

            foreach (var uf in ufs)
            {
                var incidencias = dominios.Where(d => d.uf == uf).Count();
                dicionario.Add(uf, incidencias);
            }

            return dicionario.OrderByDescending(d => d.Value);
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> ParseDominiosPorInstituição()
        {
            var dicionario = new Dictionary<string, int>();

            var instituicoes = dominios.Select(i => i.nome).Distinct();

            foreach (var instituicao in instituicoes)
            {
                var incidencias = dominios.Where(d => d.nome == instituicao).Count();
                dicionario.Add(instituicao, incidencias);
            }

            return dicionario.OrderByDescending(d => d.Value);
        }

        public IOrderedEnumerable<KeyValuePair<int, int>> ParseDominiosPorAnoDeCadastro()
        {
            var dicionario = new Dictionary<int, int>();

            var anos = dominios.Select(i => i.data_cadastro.Year).Distinct();

            foreach (var ano in anos)
            {
                var incidencias = dominios.Where(d => d.data_cadastro.Year == ano).Count();
                dicionario.Add(ano, incidencias);
            }

            return dicionario.OrderByDescending(d => d.Value);
        }

        public IOrderedEnumerable<KeyValuePair<int, int>> ParseDominiosPorMesDeCadastro()
        {
            var dicionario = new Dictionary<int, int>();

            var meses = dominios.Select(i => i.data_cadastro.Month).Distinct();

            foreach (var mes in meses)
            {
                var incidencias = dominios.Where(d => d.data_cadastro.Month == mes).Count();
                dicionario.Add(mes, incidencias);
            }

            return dicionario.OrderByDescending(d => d.Value);
        }

        public IOrderedEnumerable<KeyValuePair<int, int>> ParseDominiosPorAnoDeAtualizacao()
        {
            var dicionario = new Dictionary<int, int>();

            var anos = dominios.Select(i => i.ultima_atualizacao.Year).Distinct();

            foreach (var ano in anos)
            {
                var incidencias = dominios.Where(d => d.ultima_atualizacao.Year == ano).Count();
                dicionario.Add(ano, incidencias);
            }

            return dicionario.OrderByDescending(d => d.Value);
        }

        public IOrderedEnumerable<KeyValuePair<int, int>> ParseDominiosPorMesDeAtualizacao()
        {
            var dicionario = new Dictionary<int, int>();

            var meses = dominios.Select(i => i.ultima_atualizacao.Month).Distinct();

            foreach (var mes in meses)
            {
                var incidencias = dominios.Where(d => d.ultima_atualizacao.Month == mes).Count();
                dicionario.Add(mes, incidencias);
            }

            return dicionario.OrderByDescending(d => d.Value);
        }
    }
}

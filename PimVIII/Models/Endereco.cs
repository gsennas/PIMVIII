using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PimVIII.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }

        public Endereco()
        {
        }

        public Endereco(int id, string logradouro, int numero, int cEP, string bairro, string cidade, string estado, Pessoa pessoa)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            CEP = cEP;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pessoa = pessoa;
        }
        public Endereco(string logradouro, int numero, int cEP, string bairro, string cidade, string estado, Pessoa pessoa)
        {
            Logradouro = logradouro;
            Numero = numero;
            CEP = cEP;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pessoa = pessoa;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PimVIII.Models
{
    public class Pessoa
    {

        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        public long CPF { get; set; }
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(int id, string name, long cPF)
        {
            Id = id;
            Name = name;
            CPF = cPF;

        }
        public Pessoa(string name, long cPF)
        {
            Name = name;
            CPF = cPF;

        }
        public void AddTelefone(Telefone telefone)
        {
            Telefones.Add(telefone);
        }
    }
}

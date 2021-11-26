using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PimVIII.Models.Enum;

namespace PimVIII.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
   
        public int Numero { get; set; }
        public int DDD { get; set; }
        [Display(Name = "Tipo")]
        public TipoTelefone TipoTelefones { get; set; }

        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }

        public Telefone()
        {
        }

        public Telefone(int id, int numero, int dDD, TipoTelefone tipoTelefones, Pessoa pessoa)
        {
            Id = id;
            Numero = numero;
            DDD = dDD;
            TipoTelefones = tipoTelefones;
            Pessoa = pessoa;
        }
        public Telefone(int numero, int dDD, TipoTelefone tipoTelefones, Pessoa pessoa)
        {
            Numero = numero;
            DDD = dDD;
            TipoTelefones = tipoTelefones;
            Pessoa = pessoa;
        }
    }
}

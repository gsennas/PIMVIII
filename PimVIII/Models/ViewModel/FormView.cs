using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PimVIII.Models.ViewModel
{
    public class FormViewPessoaTelefone
    {
        public Pessoa Pessoa { get; set; }
       
        public ICollection<Telefone> Telefone { get; set; }

        
    }
}

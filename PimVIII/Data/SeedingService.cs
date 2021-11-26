using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PimVIII.Models;
using PimVIII.Models.Enum;
using PimVIII.Data;

namespace PimVIII.Data
{
    public class SeedingService
    {
        private readonly PimVIIIContext _context;

        public SeedingService(PimVIIIContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Endereco.Any() ||
                _context.Telefone.Any() ||
                _context.Pessoa.Any())
            {
                return; // DB has been seeded
            }

            Pessoa p1 = new Pessoa(1,"Glaucio Senna", 08349077719);
            Endereco e1 = new Endereco(1,"Rua Jovem Viana", 158, 28893452, "Novo Rio das Ostras", "Rio das Ostras", "Rio de Janeiro", p1);
            Telefone t1 = new Telefone(1,983653100, 021, TipoTelefone.Celular, p1);
            Telefone t5 = new Telefone(2,454545373, 021, TipoTelefone.Comercial, p1);
            Telefone t6 = new Telefone(3,454549999, 022, TipoTelefone.Celular, p1);
            Pessoa p2 = new Pessoa(2,"Joice Silva Bispo", 999999999);
            Endereco e2 = new Endereco(2,"Rua  Viana", 200, 28893452, "Novo Rio das Ostras", "Rio das Ostras", "Rio de Janeiro", p2);
            Telefone t2 = new Telefone(4,999999999, 021, TipoTelefone.Celular, p2);
            Pessoa p3 = new Pessoa(3,"Lucas Bispo Martins da Silva", 8888888888);
            Endereco e3 = new Endereco(3,"Rua Jovem" , 400, 28893452, "Novo Rio das Ostras", "Rio das Ostras", "Rio de Janeiro", p3);
            Telefone t3 = new Telefone(5,777777777, 021, TipoTelefone.Celular, p3);
            Pessoa p4 = new Pessoa(4,"Leila Senna", 6666666666);
            Endereco e4 = new Endereco(4,"Rua Lacerda", 99, 28893452, "Petropolis", "Petropolis", "Rio de Janeiro", p4);
            Telefone t4 = new Telefone(6,444444444, 021, TipoTelefone.Celular, p4);

            _context.Pessoa.AddRange(p1, p2, p3, p4);
            _context.Endereco.AddRange(e1, e2, e3, e4);
            _context.Telefone.AddRange(t1, t2, t3, t4, t5, t6);
            _context.SaveChanges();
        }
    }
    
}

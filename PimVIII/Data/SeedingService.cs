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

            Pessoa p1 = new Pessoa(1, "Camila Rosa", 99999999999);
            Endereco e1 = new Endereco(1, "Rua Orlando Bismara", 158, 00000000, "ardim Nova Manchester", "Sorocaba", "SPx", p1);
            Telefone t1 = new Telefone(1, 991889429, 015, TipoTelefone.Celular, p1);
            Telefone t5 = new Telefone(2, 888888888, 081, TipoTelefone.Comercial, p1);
            Telefone t6 = new Telefone(3, 777777777, 024, TipoTelefone.Residencial, p1);
            Pessoa p2 = new Pessoa(2, "Jonathan Fulano", 777777777777);
            Endereco e2 = new Endereco(2, "Rua Que sobe e desce", 200, 222222222, "Lua nova", "Guarapari", "Espírito Santo", p2);
            Telefone t2 = new Telefone(4, 999999999, 033, TipoTelefone.Celular, p2);
            Pessoa p3 = new Pessoa(3, "Ronei CLisman", 8888888888);
            Endereco e3 = new Endereco(3, "Rua Lair", 400, 666666666, "Nova Esperança", "Campinas", "São Paulo", p3);
            Telefone t3 = new Telefone(5, 777777777, 081, TipoTelefone.Celular, p3);


            _context.Pessoa.AddRange(p1, p2, p3);
            _context.Endereco.AddRange(e1, e2, e3);
            _context.Telefone.AddRange(t1, t2, t3, t5, t6);
            _context.SaveChanges();
        }
    }
    
}

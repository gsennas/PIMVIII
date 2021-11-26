using Microsoft.EntityFrameworkCore;
using PimVIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PimVIII.Data
{
    public class PessoaPAO
    {
        private readonly PimVIIIContext _context;

        public PessoaPAO(PimVIIIContext context) => _context = context;

        protected internal async Task Insira(Pessoa pessoa, bool saveChanges = true)
        {
            await _context.AddAsync(pessoa);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
        public async Task<List<Pessoa>> Consulte() => await _context.Pessoa.ToListAsync();

        

        protected internal async Task Altere(Pessoa pessoa, bool saveChanges = true)
        {
            _context.Update(pessoa);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
        protected internal async Task Exclua(Pessoa pessoa, bool saveChanges = true)
        {
            _context.Remove(pessoa);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
        
        protected internal async Task<Pessoa> ObterPorId(int id)
        {
            return await _context.Pessoa.FirstOrDefaultAsync(w => w.Id == id);
        }
        
    }
}

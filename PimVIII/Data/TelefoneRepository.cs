using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PimVIII.Models;

namespace PimVIII.Data
{
    public class TelefoneRepository
    {
        private readonly PimVIIIContext _context;

        public TelefoneRepository(PimVIIIContext context) => _context = context;

        protected internal async Task Insira(Telefone telefone, bool saveChanges = true)
        {
            await _context.AddAsync(telefone);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
        protected internal async Task<List<Telefone>> Consulte() => await _context.Telefone.Include(i => i.Pessoa).ToListAsync();

        protected internal async Task Altere(Telefone Telefone, bool saveChanges = true)
        {
            _context.Update(Telefone);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
        protected internal async Task Exclua(Telefone telefone, bool saveChanges = true)
        {
            _context.Remove(telefone);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
        protected internal async Task<List<Telefone>> ConsultePorPessoaId(int pessoaId, bool saveChanges = true)
        {
            return await _context.Telefone.Include(i => i.Pessoa).Where(w => w.PessoaID == pessoaId).ToListAsync();
        }
        protected internal async Task<Telefone> ObterPorId(int id)
        {
            return await _context.Telefone.Include(i => i.Pessoa).FirstOrDefaultAsync(w => w.Id == id);
        }
        protected internal Telefone ObterPorPessoaId(int pessoaId)
        {
            return  _context.Telefone.Include(i => i.Pessoa).FirstOrDefault(w => w.PessoaID == pessoaId);
        }
    }
}

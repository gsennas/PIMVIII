using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PimVIII.Models;

namespace PimVIII.Data
{
    public class EnderecoRepository
    {
        private readonly PimVIIIContext _context;

        public EnderecoRepository(PimVIIIContext context) => _context = context;

        protected internal async Task Insira(Endereco endereco, bool saveChanges = true)
        {
            await _context.AddAsync(endereco);
            if(saveChanges)
                await _context.SaveChangesAsync();
        }
        protected internal async Task<List<Endereco>> Consulte() => await _context.Endereco.Include(i => i.Pessoa).ToListAsync();
        
        protected internal async Task Altere(Endereco endereco, bool saveChanges = true)
        {
            _context.Update(endereco);
            if(saveChanges)
                await _context.SaveChangesAsync();
        }
        protected internal async Task Exclua(Endereco endereco, bool saveChanges = true)
        {
            _context.Remove(endereco);
            if(saveChanges)
                await _context.SaveChangesAsync();
        }
        protected internal async Task<List<Endereco>> ConsultePorPessoaId(int pessoaId, bool saveChanges = true)
        {
            return await _context.Endereco.Include(i => i.Pessoa).Where(w =>  w.PessoaID == pessoaId).ToListAsync();
        }
        protected internal async Task<Endereco> ObterPorId(int id)
        {
            return await _context.Endereco.Include(i => i.Pessoa).FirstOrDefaultAsync(w =>  w.Id == id);
        }
        protected internal async Task<Endereco> ObterPorPessoaId(int pessoaId)
        {
            return await _context.Endereco.Include(i => i.Pessoa).FirstOrDefaultAsync(w =>  w.PessoaID == pessoaId);
        }
    }
}
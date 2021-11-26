using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PimVIII.Data;
using PimVIII.Models;
using Microsoft.EntityFrameworkCore;
using PimVIII.Services.Exceptions;

namespace PimVIII.Services
{
    public class PessoaService
    {
        private readonly PessoaPAO _repository;

        public PessoaService(PessoaPAO repository)
        {
            _repository = repository;
        }

        public async Task<List<Pessoa>> ObterPessoa()
        {
            return await _repository.Consulte();
        }

        public async Task<Pessoa> ObterPessoaPorId(int id)
        {
            return await _repository.ObterPorId(id);
        }
        public async Task Insira(Pessoa pessoa)
        {
            await _repository.Insira(pessoa);
        }
        
        public async Task Exclua(int id)
        {
            try
            {
                var obj = await _repository.ObterPorId(id);
                await _repository.Exclua(obj);
            }
            catch
            {
                throw;
            }
        }
        public async Task Altere(Pessoa pessoa) => await _repository.Altere(pessoa);
       

    }


}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PimVIII.Data;
using PimVIII.Models;
using PimVIII.Services.Exceptions;
using PimVIII.Models.ViewModel;
using Microsoft.AspNetCore.Http;

namespace PimVIII.Services
{
    public class EnderecoService
    {

        private readonly EnderecoRepository _repository;

        public EnderecoService(EnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Endereco> ObterEnderecoPorPessoaId(int id)
        {
            return await _repository.ObterPorPessoaId(id);
        }

        public async Task<Endereco> ObterEnderecoPorId(int id)
        {
            return await _repository.ObterPorId(id);
        }
        public async Task Insira(Endereco endereco)
        {
            await _repository.Insira(endereco);
        }
        public async Task<List<Endereco>> ConsultePorPessoaId(int id)
        {
            return await _repository.ConsultePorPessoaId(id);
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
        public async Task Altere(Endereco endereco) => await _repository.Altere(endereco);
        

    }
}






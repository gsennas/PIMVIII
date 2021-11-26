using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PimVIII.Data;
using PimVIII.Models;
using PimVIII.Services.Exceptions;
using PimVIII.Models.ViewModel;
using Microsoft.AspNetCore.Http;

namespace PimVIII.Services
{
    public class TelefoneService
    {
        private readonly TelefoneRepository _repository;

        public TelefoneService(TelefoneRepository repository)
        {
            _repository = repository;
        }

        public Telefone ObterTelefonePorPessoaId(int id)
        {
            return   _repository.ObterPorPessoaId(id);
        }

        public async Task<Telefone> ObterTelefonePorId(int id)
        {
            return await _repository.ObterPorId(id);
        }
        public async Task Insira(Telefone telefone)
        {
            await _repository.Insira(telefone);
        }
        public async Task<List<Telefone>> ConsultePorPessoaId(int id)
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
        public async Task Altere(Telefone telefone) => await _repository.Altere(telefone);
        


    }
}

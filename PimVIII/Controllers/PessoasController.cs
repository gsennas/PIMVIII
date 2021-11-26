using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PimVIII.Data;
using Microsoft.EntityFrameworkCore;
using PimVIII.Services;
using PimVIII.Models;

namespace PimVIII.Controllers
{
    public class PessoasController : Controller
    {
        
        private readonly PessoaService _service;

        public PessoasController(PessoaService service)
        {            
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.ObterPessoa());
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa obj)
        {
            await _service.Insira(obj);
            return RedirectToAction(nameof(Index));
        }
        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _service.ObterPessoaPorId(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
            await _service.Exclua(id);
            return RedirectToAction(nameof(Index));
        }
        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _service.ObterPessoaPorId(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pessoa obj)
        {
            await _service.Altere(obj);
            return RedirectToAction(nameof(Index));
        }

    }
}

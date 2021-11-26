using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PimVIII.Data;
using PimVIII.Models;
using PimVIII.Services;

namespace PimVIII.Controllers
{
    public class EnderecoesController : Controller
    {

        private readonly EnderecoService _service;

        public EnderecoesController(EnderecoService service)
        {
            _service = service;
        }

        // GET: Enderecoes
        public async Task<IActionResult> Index(int id)//Funcionando
        {
            var endereco = await _service.ObterEnderecoPorPessoaId(id);
            if (endereco == null)
            {
                return RedirectToAction("Create", new { Id = id });
            }
            else
            {
                return View(endereco);
            }
        }

        // GET: Enderecoes/Create
        public async Task<IActionResult> Create(int id)
        {
            var endereco = await _service.ObterEnderecoPorPessoaId(id);
            ViewBag.PessoaId = id;
            ViewBag.Id = endereco?.Id ?? 0;
            return View(endereco);
        }

        // POST: Enderecoes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                await _service.Insira(endereco);

                return RedirectToAction("Index", "Pessoas");
            }
            return View(endereco);
        }

        // GET: Enderecoes/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _service.ObterEnderecoPorId(id.Value);
            if (endereco == null)
            {
                throw new Exception("Endereço inexistente");
            }
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Endereco endereco)
        {
            if (id != endereco.Id)
            {
                throw new Exception("Id do Endereco diferente do informado");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Altere(endereco);
                    return RedirectToAction("Index", "Pessoas");
                }
                catch (ApplicationException e)
                {
                    throw new ApplicationException(e.Message);
                }
            }
            return RedirectToAction(nameof(Index));
        }


            // GET: Enderecoes/Delete/5
            public async Task<IActionResult> Delete(int id)
            {


                var endereco = await _service.ObterEnderecoPorId(id);


                return View(endereco);
            }

            // POST: Enderecoes/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {

                await _service.Exclua(id);
                return RedirectToAction("Index", "Pessoas");
            }


        
    }
}


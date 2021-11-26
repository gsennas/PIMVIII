using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PimVIII.Data;
using PimVIII.Models;
using PimVIII.Services;

namespace PimVIII.Controllers
{
    public class TelefonesController : Controller
    {

        private readonly TelefoneService _service;

        public TelefonesController(TelefoneService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.Pessoa = id;
            return  View(await _service.ConsultePorPessoaId(id));
        }
        public IActionResult Create(int id)
        {
            Telefone telefone = new Telefone();
            ViewBag.PessoaId = id;
            ViewBag.Id = telefone?.Id ?? 0;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, Telefone telefone)
        {        
                await _service.Insira(telefone);

                return RedirectToAction("Index", "Pessoas");        
        }


        // GET: Telefones/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            
                if (id == null)
                {
                    return NotFound();
                }

            var telefone = await _service.ObterTelefonePorId(id.Value);
                if (telefone == null)
                {
                    return NotFound();
                }

                return View(telefone);
            
        }

        // Post: Telefones/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _service.Exclua(id);
            }
            return RedirectToAction("Index", "Pessoas");
        }
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _service.ObterTelefonePorId(id.Value);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);

        }

        // Post: Telefones/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                await _service.Altere(telefone);
            }
            return RedirectToAction("Index", "Pessoas");
        }
    }
}

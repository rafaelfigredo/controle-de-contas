﻿using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class ContasController : Controller
    {
        private readonly IContasService _contasService;

        public ContasController(IContasService contasService)
        {
            _contasService = contasService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _contasService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(ContasViewModel contas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contasService.Add(contas);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(contas);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var contas = await _contasService.GetById(id);

            if (contas == null) return NotFound();

            return View(contas);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var contas = await _contasService.GetById(id);

            if (contas == null) return NotFound();

            return View(contas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ContasViewModel contas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contasService.Update(contas);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(contas);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null) return NotFound();

            var contas = await _contasService.GetById(id);

            if (contas == null) return NotFound();

            return View(contas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(ContasViewModel contas)
        {
            _contasService.Remove(contas.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

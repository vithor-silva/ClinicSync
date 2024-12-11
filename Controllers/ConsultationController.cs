using ClinicSync.Models;
using ClinicSync.Services;
using ClinicSync.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicSync.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly ConsultationService _service;
        public ConsultationController(ConsultationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAllAsync());
        }

        // Exibe tela para criar nova consulta
        public IActionResult Create()
        {
            return View();
        }

        // Ação para criar uma consulta de fato
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _service.InsertAsync(consultation);

            return RedirectToAction(nameof(Index));
        }

        //Exibe tela para deletar consulta
        public async Task<ActionResult> Delete(int? id) 
        {
            if (id is null) 
            {
                return RedirectToAction(nameof(Error), new {message = "Não foi fornecido nenhum Id" });
            }

            Consultation consultation = await _service.FindByIdAsync(id.Value);
            if (consultation is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Não foi encontrado nenhum id" });
            }
            return View(consultation);
        }

        //Ação de deletar uma consulta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }
    }
}

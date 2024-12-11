using ClinicSync.Models;
using ClinicSync.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Delete() 
        {
            return View();
        }
    }
}

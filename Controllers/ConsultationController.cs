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

        public IActionResult Index()
        {
            return View();
        }
    }
}

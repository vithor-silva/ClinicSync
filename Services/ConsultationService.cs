using ClinicSync.Data;

namespace ClinicSync.Services
{
    public class ConsultationService
    {
        private readonly ClinicSyncContext _context;
        public ConsultationService(ClinicSyncContext context)
        {
            _context = context;
        }
    }
}

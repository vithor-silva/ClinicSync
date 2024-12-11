using ClinicSync.Data;
using ClinicSync.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicSync.Services
{
    public class ConsultationService
    {
        private readonly ClinicSyncContext _context;
        public ConsultationService(ClinicSyncContext context)
        {
            _context = context;
        }

        public async Task<List<Consultation>> FindAllAsync() => await _context.Consultations.ToListAsync();

        public async Task InsertAsync(Consultation consultation)
        {
            _context.Add(consultation);
            await _context.SaveChangesAsync();
        }
    }
}

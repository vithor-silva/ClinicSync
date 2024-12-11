using ClinicSync.Data;
using ClinicSync.Models;
using ClinicSync.Services.Exceptions;
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

        public async Task<Consultation> FindByIdAsync(int id)
        {
            return await _context.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Consultation consultation = await _context.Consultations.FindAsync(id);
                _context.Consultations.Remove(consultation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task UpdateAsync(Consultation consultation)
        {
            bool hasAny = await _context.Consultations.AnyAsync(c => c.Id == consultation.Id);

            if (!hasAny) 
            {
                throw new IntegrityException("ID não encontrado"); 
            }

            try
            {
                _context.Update(consultation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) 
            {
                throw new IntegrityException(ex.Message);
            }
        }
    }
}

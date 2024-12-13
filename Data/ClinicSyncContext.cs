using ClinicSync.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicSync.Data
{
    public class ClinicSyncContext : DbContext
    {
        public ClinicSyncContext(DbContextOptions<ClinicSyncContext> options) : base(options) 
        {
        }

        public DbSet<Consultation> Consultations { get; set; }
    }
}

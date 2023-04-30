using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Clinic.Application.Interfaces
{
    public interface IClinicDbContext
    {
        DatabaseFacade Database { get; }
        DbSet<Personas> Peoples { get; set; }
        DbSet<Pacientes> Patients { get; set; }
        DbSet<Maestras> Masters { get; set; }
        DbSet<DataMaestra> MasterData { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync();
        void RollbackTransaction();
    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Clinic.Domain.Entities;
using Clinic.Application.Interfaces;

namespace Clinic.Infrastructure.Persistence
{
    public class ClinicDbContext : DbContext, IClinicDbContext
    {
        private IDbContextTransaction _currentTransaction;

        public ClinicDbContext(
            DbContextOptions<ClinicDbContext> options) : base(options)
        {

        }

        public DbSet<Personas> Peoples{ get; set; }

        public DbSet<Pacientes> Patients { get; set; }

        public DbSet<Maestras> Masters { get; set; }

        public DbSet<DataMaestra> MasterData { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        break;
                    case EntityState.Modified:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(true);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }


    }
}

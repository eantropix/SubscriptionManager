using Domain.Repositories.Interfaces.UnitOfWork;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork {

        private readonly AppDbContext _Context;

        public UnitOfWork(AppDbContext context) {
            _Context = context;
        }

        public bool Commit() {
            var rows = _Context.SaveChanges();
            return (rows > 0);
        }
        public async Task<bool> CommitAsync() {
            var rows = await _Context.SaveChangesAsync();
            return (rows > 0);
        }

        public void Dispose() {
            _Context.Dispose();
        }
    }
}

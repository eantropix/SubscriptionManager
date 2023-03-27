using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.UnitOfWork {
    public class UnitOfWork {

        private readonly DbContext _Context;

        public UnitOfWork(DbContext context) {
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

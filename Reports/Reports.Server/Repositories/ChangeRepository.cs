using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Repositories
{
    public class ChangeRepository
    {
        private readonly ReportsDatabaseContext _context;

        public ChangeRepository(ReportsDatabaseContext context)
        {
            _context = context;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Change> Find(Guid id)
        {
            return await _context.Changes.FindAsync(id);
        }

        public DbSet<Change> GetAll()
        {
            return _context.Changes;
        }
    }
}
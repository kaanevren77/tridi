using Tridi.Data.Entities;

namespace Tridi.Data.Respository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TridiContext _context;

        public UnitOfWork(TridiContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

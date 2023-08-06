using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace KuberMICManager.Infrastructure.DataAccess
{
    public class SharedUnitOfWork : ISharedUnitOfWork
    {
        protected readonly MICDataContext _context;
        public ICompanyRepository CompanyRepository { get; }
        public IAttachmentRepository AttachmentRepository { get; }
        public INoteRepository NoteRepository { get; }

        public IUserDefinedFieldRepository UserDefinedFieldRepository { get; }
        public IUserDefinedTabRepository UserDefinedTabRepository { get; }
        public IUserDefinedValueRepository UserDefinedValueRepository { get; }

        public SharedUnitOfWork(MICDataContext context)
        {
            _context = context;

            CompanyRepository = new AppCompanyRepository(_context);
            AttachmentRepository = new AppAttachmentRepository(_context);
            NoteRepository = new AppNoteRepository(_context);
            UserDefinedFieldRepository = new UdfFieldRepository(_context);
            UserDefinedTabRepository = new UdfTabRepository(_context);
            UserDefinedValueRepository = new UdfValueRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync(); ;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
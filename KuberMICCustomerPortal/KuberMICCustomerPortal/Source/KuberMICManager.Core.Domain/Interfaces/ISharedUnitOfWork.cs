using KuberMICManager.Core.Domain.Interfaces.Framework;
using System;

namespace KuberMICManager.Core.Domain.Interfaces
{
    public interface ISharedUnitOfWork : IUnitOfWork, IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IAttachmentRepository AttachmentRepository { get; }
        INoteRepository NoteRepository { get; }

        // User Defined (Custom) Fields
        IUserDefinedFieldRepository UserDefinedFieldRepository { get; }
        IUserDefinedTabRepository UserDefinedTabRepository { get; }
        IUserDefinedValueRepository UserDefinedValueRepository { get; }
    }
}
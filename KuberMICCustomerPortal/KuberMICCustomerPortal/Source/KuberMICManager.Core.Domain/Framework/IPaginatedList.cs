namespace KuberMICManager.Core.Domain.Framework
{
    public interface IPaginated
    {
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
    }
}
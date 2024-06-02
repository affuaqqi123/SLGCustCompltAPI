namespace SLG.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}

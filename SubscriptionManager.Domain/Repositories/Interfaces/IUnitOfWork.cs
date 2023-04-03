namespace Domain.Repositories.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
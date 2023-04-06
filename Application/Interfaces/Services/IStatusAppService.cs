using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IStatusAppService
    {
        void Create(Status status);
        void Read(int statusId);
        void Update(Status status);
        void Delete(int statusId);
    }
}

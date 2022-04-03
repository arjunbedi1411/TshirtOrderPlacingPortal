using System.Threading.Tasks;



namespace TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract
{
    public interface IUnitOfWork
    {
        ITshirtRepository Tshirt { get; }
        Task CompleteAsync();

        void Dispose();
    }
}

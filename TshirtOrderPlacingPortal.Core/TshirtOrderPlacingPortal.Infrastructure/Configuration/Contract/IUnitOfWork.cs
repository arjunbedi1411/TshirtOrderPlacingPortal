using System.Threading.Tasks;



namespace TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract
{
    public interface IUnitOfWork
    {
        ITshirtRepository Tshirt { get; }
        IStyleRepository Style { get; }
        ISizeRepository Size { get; }
        IFileRepository Files { get; }
        Task Complete();

        void Dispose();
    }
}

using BuildingBlocks.Persistence.Mongo;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Application.Interfaces.Persistence
{
    public interface IWorkUnitRepository : IRepository<WorkUnit>
    {
        Task<bool> IsWorkUnitExistsByName(string name, string? id = null, CancellationToken cancellationToken = default);
        Task<List<WorkUnit>> GetAllByUserId(string userId, CancellationToken cancellationToken = default);
        Task<List<WorkUnit>> GetAllActiveByUserId(string userId, CancellationToken cancellationToken = default);
    }
}

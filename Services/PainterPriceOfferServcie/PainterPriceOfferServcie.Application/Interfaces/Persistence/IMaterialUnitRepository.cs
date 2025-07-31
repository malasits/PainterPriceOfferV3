using BuildingBlocks.Persistence.Mongo;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Application.Interfaces.Persistence
{
    public interface IMaterialUnitRepository: IRepository<MaterialUnit>
    {
        Task<bool> IsMaterialExistsByName(string name, string? id = null, CancellationToken cancellationToken = default);
        Task<List<MaterialUnit>> GetAllByUserId(string userId, CancellationToken cancellationToken = default);
        Task<List<MaterialUnit>> GetAllActiveByUserId(string userId, CancellationToken cancellationToken = default);
    }
}

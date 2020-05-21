using System.Threading.Tasks;
using Exercises._01_Types;

namespace Exercises._10_AsyncAwait
{
    public interface ISupplierService
    {
        Task<Money> GetPriceFor(ProductId productId);
    }
}
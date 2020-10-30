using Domain.DTO;
using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IServiceSale
    {
        Task<SaleDTO> AddCarrinho(SaleDTO sale);
    }
}

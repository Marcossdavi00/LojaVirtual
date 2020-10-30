using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryProducts
    {
        Task<ProductEntity> Insert(ProductEntity product);
        Task<IList<ProductEntity>> FindAll();
        Task<ProductEntity> FindName(string name);
        Task<ProductEntity> Update(ProductEntity product);
        Task<bool> Delete(int Id);
        Task<ProductEntity> FindById(int id);
    }
}

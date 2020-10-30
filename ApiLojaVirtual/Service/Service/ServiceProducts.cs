using Domain.Entity;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ServiceProducts: IServiceProduct
    {
        private readonly IRepositoryProducts _repository;

        public ServiceProducts(IRepositoryProducts repository)
        {
            _repository = repository;
        }


        public async Task<bool> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }

        public async Task<IList<ProductEntity>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<ProductEntity> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<ProductEntity> FindName(string name)
        {
            return await _repository.FindName(name);
        }

        public async Task<ProductEntity> Insert(ProductEntity product)
        {
            return await _repository.Insert(product);
        }

        public async Task<ProductEntity> Update(ProductEntity product)
        {
            return await _repository.Update(product);
        }
    }
}

using Domain.Entity;
using Domain.Interfaces.Repository;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryProduct : IRepositoryProducts
    {
        private readonly MyContext _context;
        private DbSet<ProductEntity> _dataset;

        public RepositoryProduct(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<ProductEntity>();
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(Id));
                if (result == null)
                    return false;
                _context.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IList<ProductEntity>> FindAll()
        {
            try
            {

                IQueryable<ProductEntity> query = _context.Products;

                query = query.OrderByDescending(d => d.Discount);

                return await query.ToArrayAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ProductEntity> FindById(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ProductEntity> FindName(string name)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Name.Equals(name));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ProductEntity> Insert(ProductEntity product)
        {
            try
            {
                _dataset.Add(product);

                await _context.SaveChangesAsync();

                return product;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ProductEntity> Update(ProductEntity product)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(product.Id));

                if (result == null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(product);

                await _context.SaveChangesAsync();

                return product;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}

using Domain.Entity;
using Domain.Interfaces.Repository;
using Moq;
using System;
using Xunit;

namespace RepositoryTestSale
{
    public class SaleTest
    {
        
        [Fact]
        public void SalvarVenda()
        {
            ProductEntity product = new ProductEntity() { Id = 1 ,Name = "Arroz", Price = 10, Discount = 5, Stock = 200 };
            SaleEntity sale = new SaleEntity();
            //sale.Product.Add(product);


            Moq.Mock<IRepositorySale> mock = new Moq.Mock<IRepositorySale>();


            IRepositorySale repository = mock.Object;


        }
    }
}

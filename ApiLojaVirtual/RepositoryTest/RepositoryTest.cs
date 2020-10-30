using Domain.Entity;
using Domain.Interfaces.Repository;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace RepositoryTest
{
    public class RepositoryTest
    {
        [Fact]
        public void SalvarProdutos()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19 , Stock = 30 };
            Moq.Mock<IRepositoryProducts> mock = new Moq.Mock<IRepositoryProducts>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);

            IRepositoryProducts repository = mock.Object;

            var result = repository.Insert(product);
            
            Assert.NotNull(result.Result);
        }
        [Fact]
        public void ListaProdutos()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };
            List<ProductEntity> products = new List<ProductEntity>();
            Moq.Mock<IRepositoryProducts> mock = new Moq.Mock<IRepositoryProducts>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);

            IRepositoryProducts repository = mock.Object;

            repository.Insert(product);

            mock.Setup(p => p.FindAll()).ReturnsAsync(products);

            repository = mock.Object;

            var result = repository.FindAll();

            Assert.NotNull(result.Result);
        }
        [Fact]
        public void MOstrarProdutoPeloNome()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };
            Moq.Mock<IRepositoryProducts> mock = new Moq.Mock<IRepositoryProducts>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);
            mock.Setup(p => p.FindName(product.Name)).ReturnsAsync(product);

            IRepositoryProducts repository = mock.Object;

            repository.Insert(product);
            var result = repository.FindName(product.Name);

            Assert.NotNull(result.Result);
        }
        [Fact]
        public void EditarProduto()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };
            Moq.Mock<IRepositoryProducts> mock = new Moq.Mock<IRepositoryProducts>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);
            IRepositoryProducts repository = mock.Object;
            repository.Insert(product);
            product.Name = "Feijão";
            mock.Setup(p => p.Update(product)).ReturnsAsync(product);

            repository = mock.Object;

            var result = repository.Update(product);

            Assert.NotNull(result.Result);
        }
        [Fact]
        public void DeletarProduto()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };

            Moq.Mock<IRepositoryProducts> mock = new Moq.Mock<IRepositoryProducts>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);
            mock.Setup(p => p.Delete(product.Id)).ReturnsAsync(true);

            IRepositoryProducts repository = mock.Object;

            repository.Insert(product);
            var result = repository.Delete(product.Id);

            Assert.True(result.Result);
        }
    }
}

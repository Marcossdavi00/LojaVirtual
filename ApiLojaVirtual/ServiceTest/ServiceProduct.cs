using Domain.Entity;
using Domain.Interfaces.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ServiceTest
{
    public class ServiceProduct
    {
        [Fact]
        public void SalvarProdutos()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };
            Moq.Mock<IServiceProduct> mock = new Moq.Mock<IServiceProduct>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);

            IServiceProduct service = mock.Object;

            var result = service.Insert(product);

            Assert.NotNull(result.Result);
        }
        [Fact]
        public void ListaProdutos()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };
            List<ProductEntity> products = new List<ProductEntity>();
            Moq.Mock<IServiceProduct> mock = new Moq.Mock<IServiceProduct>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);

            IServiceProduct service = mock.Object;

            service.Insert(product);

            mock.Setup(p => p.FindAll()).ReturnsAsync(products);

            service = mock.Object;

            var result = service.FindAll();

            Assert.NotNull(result.Result);
        }
        [Fact]
        public void MOstrarProdutoPeloNome()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };
            Moq.Mock<IServiceProduct> mock = new Moq.Mock<IServiceProduct>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);
            mock.Setup(p => p.FindName(product.Name)).ReturnsAsync(product);

            IServiceProduct service = mock.Object;

            service.Insert(product);
            var result = service.FindName(product.Name);

            Assert.NotNull(result.Result);
        }
        [Fact]
        public void EditarProduto()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };
            Moq.Mock<IServiceProduct> mock = new Moq.Mock<IServiceProduct>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);
            IServiceProduct service = mock.Object;
            service.Insert(product);
            product.Name = "Feijão";
            mock.Setup(p => p.Update(product)).ReturnsAsync(product);

            service = mock.Object;

            var result = service.Update(product);

            Assert.NotNull(result.Result);
        }
        [Fact]
        public void DeletarProduto()
        {
            ProductEntity product = new ProductEntity() { Name = "Arroz", Discount = 20, Price = 19, Stock = 30 };

            Moq.Mock<IServiceProduct> mock = new Moq.Mock<IServiceProduct>();
            mock.Setup(p => p.Insert(product)).ReturnsAsync(product);
            mock.Setup(p => p.Delete(product.Id)).ReturnsAsync(true);

            IServiceProduct service = mock.Object;

            service.Insert(product);
            var result = service.Delete(product.Id);

            Assert.True(result.Result);
        }
    }
}

using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IServiceProduct _service;
        private readonly IServiceSale _sale;

        public static List<ProductDto> itens { get; set; }

        public ProductsController(IServiceProduct service, IServiceSale sale)
        {
            _service = service;
            _sale = sale;
        }
        //Tela Lista de Produtos
        public async Task<ActionResult> ListProduct()
        {
            try
            {
                var result = await _service.FindAll();

                return View(result);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        //Tela Buscar por Nome
        public async Task<ActionResult> BuscarPorNome(string Name)
        {
            try
            {
                if (Name == null)
                    return RedirectToAction(nameof(ListProduct));

                var result = await _service.FindName(Name);

                return View(result);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        //Tela de Criar Produto
        public ActionResult Create()
        {
            return View();
        }
        //Criar Produto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductEntity product)
        {
            try
            {
                await _service.Insert(product);

                return RedirectToAction(nameof(ListProduct));
            }
            catch
            {
                return View();
            }
        }
        //Tela de Editar produto
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var result = await _service.FindById(id);
                return View(result);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        //Editar Produto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductEntity product)
        {
            try
            {
                await _service.Update(product);

                return RedirectToAction(nameof(ListProduct));
            }
            catch
            {
                return View();
            }
        }
        //Deletar Produtor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(ListProduct));
            }
            catch
            {
                return View();
            }
        }
        //Adicionar produto no carrinho
        [HttpPost]
        public async Task<ActionResult> AddProduct(int id, int quantidade)
        {
            try
            {
                if (itens == null)
                {
                    itens = new List<ProductDto>();
                }
                if(quantidade <= 0)
                {
                    return RedirectToAction(nameof(ListProduct));
                }

                    foreach (var i in itens)
                    {
                        if(i.Id == id)
                        {
                            i.Amount = i.Amount + quantidade;

                            return RedirectToAction(nameof(ListProduct));
                        }
                    }

                var result = await _service.FindById(id);

                itens.Add(new ProductDto { Id = result.Id, Name = result.Name, Price = result.Price, Discont = result.Discount, Amount = quantidade });

                return RedirectToAction(nameof(ListProduct));
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //Visualizar Produtos no Carrinho
        public async Task<ActionResult> Carrinho()
        {
            try
            {
                if(itens == null)
                {
                    return RedirectToAction(nameof(ListProduct));
                }

                SaleDTO venda = new SaleDTO() { products = itens};

                var result = await _sale.AddCarrinho(venda);

                return View(result);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //Finalizando a Comprar
        [HttpPost]
        public async Task<ActionResult> FinalizarCompra(SaleDTO sale)
        {
            try
            {
                SaleDTO dTO = new SaleDTO { products = itens, Frete = sale.Frete, TotalValue = sale.TotalValue };


                foreach (var i in dTO.products)
                {
                    var product = await _service.FindById(i.Id);
                    var quantidade = i.Amount;
                    product.Stock = product.Stock - quantidade;
                    await _service.Update(product);
                }

                itens = new List<ProductDto>();

                return RedirectToAction(nameof(ListProduct));

            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

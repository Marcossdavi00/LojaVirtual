using Domain.DTO;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ServiceSale : IServiceSale
    {

        public async Task<SaleDTO> AddCarrinho(SaleDTO sale)
        {
            try
            {
                int cont = 0;

                foreach (var item in sale.products)
                {
                    item.TotalPriceProduct = item.Price * item.Amount;
                    sale.TotalValue = item.TotalPriceProduct + sale.TotalValue;
                    if (item.Discont > 0)
                    {
                        cont++;
                    }
                }
                //Frete
                if (sale.TotalValue <= 100)
                {
                    sale.Frete = 25;
                }
                else if (sale.TotalValue > 100 && sale.TotalValue <= 250)
                {
                    sale.Frete = (sale.TotalValue * 20) / 100;
                }
                else if (sale.TotalValue > 250)
                {
                    sale.Frete = 0;
                }

                //Desconto
                if (sale.TotalValue > 100 || cont == 0)
                {
                    sale.TotalValue = sale.TotalValue - ((sale.TotalValue * 10) / 100);
                };

                return sale;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using Domain.Entity;

namespace Domain.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discont { get; set; }
        public int  Amount { get; set; }
        public double TotalPriceProduct { get; set; }
        public double Frete { get; set; }
        public double TotalSale { get; set; }


    }
}

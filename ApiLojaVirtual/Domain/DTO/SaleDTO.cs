using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class SaleDTO
    {
        public List<ProductDto> products { get; set; }
        public double Frete { get; set; }
        public double TotalValue { get; set; }
    }
}

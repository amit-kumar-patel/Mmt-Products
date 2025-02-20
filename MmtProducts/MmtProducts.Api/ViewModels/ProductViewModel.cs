﻿namespace MmtProducts.Api.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int Sku { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}

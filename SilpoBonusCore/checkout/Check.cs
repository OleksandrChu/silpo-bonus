using System;
using System.Collections.Generic;

namespace SilpoBonusCore
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private int totalCost;
        public int GetTotalCost()
        {
            int totalCost = 0;
            products.ForEach(product => totalCost+=product.price);
            return totalCost;
        }

        internal void AddProduct(Product product)
        {
            products.Add(product);
        }

    }
}
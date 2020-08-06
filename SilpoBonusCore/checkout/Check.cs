using System;
using System.Collections.Generic;

namespace SilpoBonusCore.checkout
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private int points = 0;

        public int GetTotalCost()
        {
            int totalCost = 0;
            products.ForEach(product => totalCost+=product.price);
            return totalCost;
        }

        internal void AddProduct(Product product) =>products.Add(product);

        public int GetTotalPoints() => GetTotalCost() + points;

        public void AddPoints(int points) => this.points += points;

        internal int GetCostByCategory(Category category)
        {
            int cost = 0;
            foreach (Product product in products)
            {
                if (product.category == category)
                {
                    cost += product.price;
                }
            }

            return cost;
        }
    }
}
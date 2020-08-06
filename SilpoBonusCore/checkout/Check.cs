using System.Linq;
using System.Collections.Generic;

namespace SilpoBonusCore.checkout
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private int points = 0;

        public int GetTotalCost() => products.Sum(product => product.price);
        internal void AddProduct(Product product) => products.Add(product);
        public int GetTotalPoints() => GetTotalCost() + points;

        internal void AddPoints(int points) => this.points += points;

        internal int GetCostByCategory(Category category)
        {
            return products
            .Where(product => product.category.Equals(category))
            .Sum(product => product.price);
        }
    }
}
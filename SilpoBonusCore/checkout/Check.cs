using System.Linq;
using System.Collections.Generic;
using System;
using SilpoBonusCore.offers;
using SilpoBonusCore.models;

namespace SilpoBonusCore.checkout
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private List<Offer> offers = new List<Offer>();
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

        internal void AddOffer(Offer offer) => offers.Add(offer);

        internal void UseOffers() => offers.ForEach(offer => offer.TryToApply(this));
    }
}
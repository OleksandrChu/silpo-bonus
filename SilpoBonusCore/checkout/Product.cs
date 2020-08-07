using SilpoBonusCore.models;

namespace SilpoBonusCore.checkout
{
    public class Product
    {
        public int price;
        public string name;
        public Category category;
        internal Trade trade;

        public Product(int price, string name)
        {
            this.price = price;
            this.name = name;
        }

        public Product(int price, string name, Category category, Trade trade)
        {
            this.price = price;
            this.name = name;
            this.category = category;
            this.trade = trade;
        }
    }
}
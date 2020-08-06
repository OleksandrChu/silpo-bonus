namespace SilpoBonusCore.checkout
{
    public class Product
    {
        public int price;
        public string name;
        public Category category;

        public Product(int price, string name)
        {
            this.price = price;
            this.name = name;
        }

        public Product(int price, string name, Category category)
        {
            this.price = price;
            this.name = name;
            this.category = category;
        }
    }
}
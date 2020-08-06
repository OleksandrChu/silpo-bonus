namespace SilpoBonusCore
{
    public class AnyGoodOffer
    {
        public readonly int totalCost;
        public readonly int points;

        public AnyGoodOffer(int totalCost, int points)
        {
            this.totalCost = totalCost;
            this.points = points;
        }
    }
}
using SilpoBonusCore.checkout;

namespace SilpoBonusCore.rewards
{
    public class Flat : IReward
    {
        private int points;

        public Flat(int points)
        {
            this.points = points;
        }

        public int CalcPoints(Check check) => points;
    }
}
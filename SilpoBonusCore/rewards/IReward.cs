using SilpoBonusCore.checkout;

namespace SilpoBonusCore.rewards
{
    public interface IReward
    {
        int CalcPoints(Check check);
    }
}
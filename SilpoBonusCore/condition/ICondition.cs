using SilpoBonusCore.checkout;

namespace SilpoBonusCore.condition
{
    public interface ICondition
    {
        bool Check(Check check);
    }
}
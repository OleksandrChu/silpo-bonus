using System;
using SilpoBonusCore.checkout;

namespace SilpoBonusCore.offers
{
   
    public abstract class Offer
    {
        protected DateTime expirationDate;
        public abstract void Apply(Check check);

        public abstract bool IsSatisfyCondition(Check check);

        public void TryToApply(Check check)
        {
            if (IsNotExpired() && IsSatisfyCondition(check))
            {
                Apply(check);
            }
        }

        private bool IsNotExpired()
        {
            TimeSpan timeSpan = expirationDate - DateTime.Now;
            return timeSpan.Days >= 0;
        }
    }
}

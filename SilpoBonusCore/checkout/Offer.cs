using System;

namespace SilpoBonusCore.checkout
{
    public abstract class Offer
    {
        protected DateTime expirationDate;
        public abstract void Apply(Check check);

        public void TryToApply(Check check)
        {
            if (IsNotExpired())
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

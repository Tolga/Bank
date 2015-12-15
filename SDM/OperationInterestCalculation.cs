namespace SDM
{
    using System.Collections.Generic;
    using Interfaces;

    abstract class OperationInterestCalculation : IOperation
    {
        public abstract List<IOpHistory> History { get; set; }

        public abstract float CalculateInterest(Account ac);
        public abstract ICommand Commit();
    }
}

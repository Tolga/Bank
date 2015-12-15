namespace SDM
{
    class OperationInterestCalculationDeposit : OperationInterestCalculation
    {
        private Deposit deposit;

        public OperationInterestCalculationDeposit(Deposit deposit)
        {
            this.deposit = deposit;
        }

        public override float CalculateInterest(Account ac)
        {
			return ac.Balance*0.05f;
        }
    }
}

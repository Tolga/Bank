using System;
using Itenso.TimePeriod;

namespace SDM
{
    using Interfaces;

    public abstract class InterestRate : IInterestRate
    {
        public IAccount Account { get; set; }
        public abstract void Calculate();
        public abstract float Check();
    }

    public class Normal : IInterestRate
    {
        private const float Rate = 0.05F;
        private const float PenaltyRate = 0.025F;
        private const float Peak = 4999.00F;

        public IAccount Account { get; set; }

        public Normal(IAccount account)
        {
            Account = account;
        }

        public void Calculate()
        {
            // Check for early close of deposit
            if (Account.Type == AccountType.Deposit && DateTime.Now < Account.CloseDate)
            {
                var elapsedMonths = new DateDiff(Account.OpenDate, DateTime.Now).ElapsedMonths;
                Account.Balance += Account.Balance * (elapsedMonths / 12) * PenaltyRate;
            }
            else
            {
                var elapsedMonths = new DateDiff(Account.OpenDate, DateTime.Now).ElapsedMonths;
                Account.Balance += Account.Balance * (elapsedMonths / 12) * Rate;
            }
            Check();
        }

        public float Check()
        {
            if (Account.Balance > Peak)
            {
                Account.State = new Premium(Account);
                Account.History.Add(new OperationHistory("Your account state changed to Premium!", true, DateTime.Now));
            }
            return Rate;
        }
    }
    
    public class Premium : IInterestRate
    {
        private const float Rate = 0.1F;
        private const float PenaltyRate = 0.05F;
        private const float Peak = 5000.00F;
        public IAccount Account { get; set; }

        public Premium(IAccount account)
        {
            Account = account;
        }

        public void Calculate()
        {
            // Check for early close of deposit
            if (Account.Type == AccountType.Deposit && DateTime.Now < Account.CloseDate)
            {
                var elapsedMonths = new DateDiff(Account.OpenDate, DateTime.Now).ElapsedMonths;
                Account.Balance += Account.Balance * (elapsedMonths / 12) * PenaltyRate;
            }
            else
            {
                var elapsedMonths = new DateDiff(Account.OpenDate, DateTime.Now).ElapsedMonths;
                Account.Balance += Account.Balance * (elapsedMonths / 12) * Rate;
            }
            Check();
        }

        public float Check()
        {
            if (Account.Balance < Peak)
            {
                Account.State = new Normal(Account);
                Account.History.Add(new OperationHistory("Your account state changed to Normal!", true, DateTime.Now));
            }

            return Rate;
        }
    }
}

using System;
using Itenso.TimePeriod;

namespace SDM
{
    using Interfaces;

    public abstract class InterestRate : IInterestRate
    {
        public abstract void Calculate();
        public abstract float Check();
    }

    public class Normal : IInterestRate
    {
        private const float Rate = 0.05F;
        private const float PenaltyRate = 0.025F;
        private const float Peak = 4999.00F;

        private IAccount Account { get; }

        public Normal(IAccount account)
        {
            Account = account;
        }

        public void Calculate()
        {
            var elapsedMonths = new DateDiff(Account.OpenDate, DateTime.Now).Months;

            // Check for early close of deposit
            if (Account.Type == AccountType.Deposit)
            {
                if (elapsedMonths < 12)
                {
                    Account.Balance += Account.Balance * (elapsedMonths / 12) * PenaltyRate;
                    Account.History.Add(new OperationHistory("PENALTY", true, DateTime.Now));
                }
                else
                {
                    Account.Balance += Account.Balance * (elapsedMonths / 12) * Rate;
                    Account.History.Add(new OperationHistory("NORMAL", true, DateTime.Now));
                }
            }
            else if (Account.Type == AccountType.Loan)
            {
                Account.Balance += Account.Balance * (elapsedMonths / 12) * Rate;
            }
            else
            {
                Account.Balance += Account.Balance * Rate;
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
        private IAccount Account { get; }

        public Premium(IAccount account)
        {
            Account = account;
        }

        public void Calculate()
        {
            var elapsedMonths = new DateDiff(Account.OpenDate, DateTime.Now).Months;

            // Check for early close of deposit
            if (Account.Type == AccountType.Deposit)
            {
                if (elapsedMonths < 12)
                {
                    Account.Balance += Account.Balance * (elapsedMonths/12) * PenaltyRate;
                    Account.History.Add(new OperationHistory("PENALTY", true, DateTime.Now));
                }
                else
                {
                    Account.Balance += Account.Balance * (elapsedMonths / 12) * Rate;
                    Account.History.Add(new OperationHistory("PREMIUM", true, DateTime.Now));
                }
            }
            else if (Account.Type == AccountType.Loan)
            {
                Account.Balance += Account.Balance * (elapsedMonths / 12) * Rate;
            }
            else
            {
                Account.Balance += Account.Balance * Rate;
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

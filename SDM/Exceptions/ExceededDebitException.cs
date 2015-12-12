using System;

namespace SDM.Exceptions
{
    class ExceededDebitException : ArgumentException
    {
        public ExceededDebitException()
        {
        }

        public ExceededDebitException(string message) : base("Balance exceeded allowed debit")
        {
        }

    }
}

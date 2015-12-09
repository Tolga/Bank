using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.Exceptions
{
    class ExceededDebitException : ArgumentException
    {
        public ExceededDebitException()
        {
        }

        public ExceededDebitException(string message)
            : base("Balance exceeded allowed debit")
        {
        }

    }
}

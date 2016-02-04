using SDM.Interfaces;
// <copyright file="BankTest.cs">Copyright ©  2015</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM;

namespace SDM.Tests
{
    [TestClass]
    [PexClass(typeof(Bank))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class BankTest
    {

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public void Send(
            [PexAssumeUnderTest]Bank target,
            ICustomer from,
            ICustomer to,
            float amount
        )
        {
            target.Send(from, to, amount);
            // TODO: add assertions to method BankTest.Send(Bank, ICustomer, ICustomer, Single)
        }
    }
}

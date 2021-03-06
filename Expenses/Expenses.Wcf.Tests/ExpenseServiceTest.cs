using Expenses.Data.CommunicationModels;
// <copyright file="ExpenseServiceTest.cs">Copyright ©  2014</copyright>

using System;
using Expenses.Wcf;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expenses.Wcf.Tests
{
    [TestClass]
    [PexClass(typeof(ExpenseService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ExpenseServiceTest
    {

        [PexMethod]
        public int CreateNewCharge([PexAssumeUnderTest]ExpenseService target, Charge charge)
        {
            int result = target.CreateNewCharge(charge);
            return result;
            // TODO: add assertions to method ExpenseServiceTest.CreateNewCharge(ExpenseService, Charge)
        }
    }
}

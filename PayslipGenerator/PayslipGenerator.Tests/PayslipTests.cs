using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipGenerator.Api;

namespace PayslipGenerator.Tests
{
    [TestClass]
    public class PayslipTests
    {
        [TestMethod]
        public void Can_create_payslip()
        {
            // Given
            string name = "any name";
            string payPeriod = "June";
            int grossIncome = 12345;
            int incomeTax = 111;
            int netIncome = grossIncome - incomeTax;
            int superRate = 4 / 100;
            int super = grossIncome * superRate;

            // When
            Payslip payslip = new Payslip(name, payPeriod, grossIncome, incomeTax, superRate);

            // Then 
            Assert.AreEqual(payslip.Name, name);
            Assert.AreEqual(payslip.PayPeriod, payPeriod);
            Assert.AreEqual(payslip.GrossIncome, grossIncome);
            Assert.AreEqual(payslip.IncomeTax, incomeTax);
            Assert.AreEqual(payslip.NetIncome, netIncome);
            Assert.AreEqual(payslip.Super, super);

        }
    }
}

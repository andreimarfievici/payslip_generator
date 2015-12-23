using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipGenerator.Factory;
using PayslipGenerator.Api;

namespace PayslipGenerator.Tests
{
    [TestClass]
    public class PayslipFactoryTests
    {

        [TestMethod]
        public void Can_generate_payslip_for_given_employee_0_18200()
        {
            Can_generate_payslip_for_given_employee(15000);
        }

        [TestMethod]
        public void Can_generate_payslip_for_given_employee_18201_37000()
        {
            Can_generate_payslip_for_given_employee(25000);
        }

        [TestMethod]
        public void Can_generate_payslip_for_given_employee_37001_80000()
        {
            Can_generate_payslip_for_given_employee(50000);
        }

        [TestMethod]
        public void Can_generate_payslip_for_given_employee_80001_180000()
        {
            Can_generate_payslip_for_given_employee(130000);
        }

        [TestMethod]
        public void Can_generate_payslip_for_given_employee_180000_over()
        {
            Can_generate_payslip_for_given_employee(200000);
        }

        private void Can_generate_payslip_for_given_employee(int annualSalary)
        {
            // Given
            string firstName = "John";
            string lastName = "Snow";
            int expectedGrossIncome = Convert.ToInt32(Math.Round(Convert.ToDouble(annualSalary / 12)));
            int expectedIncomeTax = calculateIncomeTax(annualSalary);
            int expectedNetIncome = expectedGrossIncome - expectedIncomeTax;
            string expectedPaymentStartDate = "March";
            double superRate = 7;
            int expectedSuper = Convert.ToInt32(Math.Round(Convert.ToDouble(expectedGrossIncome * superRate / 100)));

            // When
            Payslip payslip = PayslipFactory.generate(new Employee(firstName, lastName, annualSalary, superRate, expectedPaymentStartDate));

            // Then
            Assert.AreEqual(payslip.Name, string.Concat(firstName, " ", lastName));
            Assert.AreEqual(payslip.GrossIncome, expectedGrossIncome);
            Assert.AreEqual(payslip.IncomeTax, expectedIncomeTax);
            Assert.AreEqual(payslip.NetIncome, expectedNetIncome);
            Assert.AreEqual(payslip.PayPeriod, expectedPaymentStartDate);
            Assert.AreEqual(payslip.Super, expectedSuper);
        }

        private int calculateIncomeTax(int annualSalary)
        {
            int incomeTax = new int();

            if (0 < annualSalary && annualSalary <= 18200)
            {
                incomeTax = 0;
            }
            else if (18200 < annualSalary && annualSalary <= 37000)
            {
                incomeTax = Convert.ToInt32(Math.Round((annualSalary - 18200) * 0.19/12));
            }
            else if (37000 < annualSalary && annualSalary <= 80000)
            {
                incomeTax = Convert.ToInt32(3572 + Math.Round((annualSalary - 37000) * 0.325/12));
            }
            else if (80000 < annualSalary && annualSalary <= 180000)
            {
                incomeTax = Convert.ToInt32(17547 + Math.Round((annualSalary - 80000) * 0.37/12));
            }
            else if (annualSalary > 180000)
            {
                incomeTax = Convert.ToInt32(54547 + Math.Round((annualSalary - 180000) * 0.45/12));
            }

            return incomeTax;
        }
    }
}

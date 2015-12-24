using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipGenerator.Api;

namespace PayslipGenerator.Tests
{
    [TestClass]
    public class EmployeeTests    
    {
        [TestMethod]
        public void Can_create_an_employee()
        {
            // Given
            string firstName = "John";
            string lastName = "Snow";
            int annualSalary = 123000;
            double superRate = 0.3;
            string paymentStartDate = "test";


            // When
            Employee employee = new Employee(firstName, lastName, annualSalary, superRate, paymentStartDate);

            // Then
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(annualSalary, employee.AnnualSalary);
            Assert.AreEqual(superRate, employee.SuperRate);
            Assert.AreEqual(paymentStartDate, employee.PaymentStartDate);

        }
    }
}

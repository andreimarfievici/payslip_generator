using System;

namespace PayslipGenerator.Api
{
    public class Employee
    {
        private int annualSalary;
        private string firstName;
        private string lastName;
        private string paymentStartDate;
        private double superRate;

        public Employee(string firstName, string lastName, int annualSalary, double superRate, string paymentStartDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.annualSalary = annualSalary;
            this.superRate = superRate;
            this.paymentStartDate = paymentStartDate;
        }

        public int AnnualSalary
        {
            get
            {
                return annualSalary;
            }

            set
            {
                annualSalary = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public String PaymentStartDate
        {
            get
            {
                return paymentStartDate;
            }

            set
            {
                paymentStartDate = value;
            }
        }

        public double SuperRate
        {
            get
            {
                return superRate;
            }

            set
            {
                superRate = value;
            }
        }
    }
}
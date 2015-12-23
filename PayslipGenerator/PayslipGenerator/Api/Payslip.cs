namespace PayslipGenerator.Api
{
    public class Payslip
    {
        private string name;
        private int grossIncome;
        private int incomeTax;
        private string payPeriod;
        private int super;

        public Payslip(string name, string payPeriod, int grossIncome, int incomeTax, int super)
        {
            this.name = name;
            this.payPeriod = payPeriod;
            this.grossIncome = grossIncome;
            this.incomeTax = incomeTax;
            this.super = super;
        }

        public int GrossIncome
        {
            get
            {
                return grossIncome;
            }
        }

        public int IncomeTax
        {
            get
            {
                return incomeTax;
            }
        }

        public string PayPeriod
        {
            get
            {
                return payPeriod;
            }
        }

        public int Super
        {
            get
            {
                return super;
            }
        }

        public int NetIncome
        {
            get
            {
                return this.grossIncome - this.incomeTax;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
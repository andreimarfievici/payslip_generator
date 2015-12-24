using System;
using System.Web.UI;
using PayslipGenerator.Api;
using PayslipGenerator.Factory;
using System.Globalization;
using System.Drawing;
using System.Web.UI.WebControls;

namespace PayslipGenerator
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GeneratePayslipInformation(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                GeneratePayslipErrorLabel.Visible = false;
                Employee employee = new Employee(FirstNameField.Text,
                    LastNameField.Text,
                    int.Parse(AnnualSalaryField.Text),
                    double.Parse(SuperRateField.Text),
                    PaymentStartDateList.Text);
                    displayPayslipInfo(PayslipFactory.generate(employee));
            }
            else
            {
                disablePayslipInfo();
            }

        }

        private void displayPayslipInfo(Payslip payslip)
        {
            NameDisplay.Text = payslip.Name;
            PayPeriodDisplay.Text = payslip.PayPeriod.ToString();
            GrossIncomeDisplay.Text = payslip.GrossIncome.ToString();
            IncomeTaxDisplay.Text = payslip.IncomeTax.ToString();
            NetIncomeDisplay.Text = payslip.NetIncome.ToString();
            SuperDisplay.Text = payslip.Super.ToString();
            PayslipInfo.Visible = true;
        }

        private void disablePayslipInfo()
        {
            PayslipInfo.Visible = false;
            GeneratePayslipErrorLabel.ForeColor = Color.Red;
            GeneratePayslipErrorLabel.Visible = true;
        }

        private bool isFormValid()
        {
            int annualSalary;
            double superRate;

            return !string.IsNullOrWhiteSpace(FirstNameField.Text) &&
                !string.IsNullOrWhiteSpace(LastNameField.Text) &&
                !string.IsNullOrWhiteSpace(LastNameField.Text) &&
                int.TryParse(AnnualSalaryField.Text, out annualSalary) &&
                annualSalary > 0 &&
                double.TryParse(SuperRateField.Text, out superRate) &&
                superRate >= 0 &&
                superRate <=50 &&
                Array.Exists(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, month => month == PaymentStartDateList.Text);

        }
    }
}
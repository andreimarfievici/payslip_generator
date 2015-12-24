using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using PayslipGenerator.Api;
using PayslipGenerator.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PayslipGenerator.Specs.Steps
{
    [Binding]
    public class PayslipGeneratorSteps
    {
        IWebDriver driver;
        Employee employee;
        Payslip payslip;
        private readonly string CHROMEDRIVER_PATH = string.Concat(System.IO.Directory.GetCurrentDirectory(), "\\..\\PayslipGenerator.Specs\\chromedriver");
        const int iisPort = 2020;
        private readonly string _applicationName;
        private Process _iisProcess;

        private void StartIIS()
        {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + "\IIS Express\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = string.Format("/path:"{ 0}
            " /port:{1}", applicationPath, iisPort);
            _iisProcess.Start();
        }


        protected virtual string GetApplicationPath(string applicationName)
        {
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }


        public string GetAbsoluteUrl(string relativeUrl)
        {
            if (!relativeUrl.StartsWith("/"))
            {
                relativeUrl = "/" + relativeUrl;
            }
            return String.Format("http://localhost:{0}{1}", iisPort, relativeUrl);
        }

        [Before]
        public void setUp()
        {
            driver = new ChromeDriver(CHROMEDRIVER_PATH);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            employee = new Employee("John", "Snow", 123456, 7.89, "July");
        }

        [Given]
        public void Given_I_am_on_the_payslip_generator_page()
        {
            driver.Navigate().GoToUrl("http://localhost:58848/PayslipGenerator");
        }
        
        [When]
        public void When_I_enter_employee_details()
        {
            driver.FindElement(By.Id("MainContent_FirstNameField")).SendKeys(employee.FirstName);
            driver.FindElement(By.Id("MainContent_LastNameField")).SendKeys(employee.LastName);
            driver.FindElement(By.Id("MainContent_AnnualSalaryField")).SendKeys(employee.AnnualSalary.ToString());
            driver.FindElement(By.Id("MainContent_SuperRateField")).SendKeys(employee.SuperRate.ToString());
            new SelectElement(driver.FindElement(By.Id("MainContent_PaymentStartDateList"))).SelectByText(employee.PaymentStartDate);
        }
        
        [When]
        public void When_I_generate_payslip()
        {
            payslip = PayslipFactory.generate(employee);
            driver.FindElement(By.Id("MainContent_GeneratePayslip")).Click();
        }
        
        [Then]
        public void Then_I_should_see_payslip_information()
        {
            Assert.AreEqual(payslip.Name, driver.FindElement(By.Id("MainContent_NameDisplay")).Text);
            Assert.AreEqual(payslip.PayPeriod, driver.FindElement(By.Id("MainContent_PayPeriodDisplay")).Text);
            Assert.AreEqual(payslip.GrossIncome.ToString(), driver.FindElement(By.Id("MainContent_GrossIncomeDisplay")).Text);
            Assert.AreEqual(payslip.IncomeTax.ToString(), driver.FindElement(By.Id("MainContent_IncomeTaxDisplay")).Text);
            Assert.AreEqual(payslip.NetIncome.ToString(), driver.FindElement(By.Id("MainContent_NetIncomeDisplay")).Text);
            Assert.AreEqual(payslip.Super.ToString(), driver.FindElement(By.Id("MainContent_SuperDisplay")).Text);
        }

        [After]
        public void cleanUp()
        {
            driver.Close();
            killChromeDriver();
        }

        private static void killChromeDriver()
        {
            foreach (Process p in Process.GetProcessesByName("chromedriver"))
            {
                p.Kill();
            }
        }
    }
}

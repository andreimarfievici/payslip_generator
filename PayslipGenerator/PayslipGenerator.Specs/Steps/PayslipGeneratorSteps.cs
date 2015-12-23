using System;
using TechTalk.SpecFlow;

namespace PayslipGenerator.Specs.Steps
{
    [Binding]
    public class PayslipGeneratorSteps
    {
        [Given]
        public void Given_I_am_on_the_payslip_generator_page()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_I_enter_employee_details()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_I_generate_payslip()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_I_should_see_payslip_information()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

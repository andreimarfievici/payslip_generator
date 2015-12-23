Feature: PayslipGenerator
	In order to pay employees
	As an HR administrator
	I want to be able to generate payslips

Scenario: User should be able to generate payslip for given employee input
	Given I am on the payslip generator page
	When I enter employee details
	And I generate payslip
	Then I should see payslip information
	
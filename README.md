# Payslip Generator

*This solution was built using MS Visual Studio Community 2015.*

##Prerequisites

In order to run this project, you need to have already installed:

- Github
- MS Visual Studio
- Google Chrome (for running the acceptance tests)

Once all of the above are met, you can clone the project locally using GIT:

```
git clone https://github.com/andreimarfievici/payslip_generator.git
```

##Building the solution

- Open "PayslipGenerator.sln" in VS
- Build Solution: *Ctrl+Shift+B* or *Build > Build Solution* in the top menu

*This will download all the necessary dependencies required to run the acceptance tests using SpecFlow.*

##Running the solution

- Select a browser (eg: Chrome) and hit the Play button in the Debug Menu to start the IIS express
- Navigate to http://localhost:58848/PayslipGenerator
- Play and Enjoy!

##Running the unit and acceptance tests

*In order to run these tests, it is assumed the IIS express has been started at least once (check step above).*

- Run all tests using *Ctrl+R+A* or go to *Test > Run > All Tests*

*This will run all the Unit Tests and the Acceptance Tests.*

##Evaluating tests results

- Once tests are run, you can check results in VS Test Explorer panel
- You can check acceptance tests HTML report in the output link (use *Ctrl+Click* to open report in VS, eg: *Report file: file:///C:\git\stuff\PayslipGenerator\TestResults\PayslipGenerator.Specs_Default_2016-01-05T113730.html*)

##Solution structure

*This solution was built using a standard C# Web Application template.*

There are 3 projects:

- "PayslipGenerator" - the web app
- "PayslipGenerator.Specs" - the BDD acceptance tests using SpecFlow
- "PayslipGenerator.Tests" - the unit tests

##Development practices used

This solution was built entirely using **BDD** and **TDD** techniques. The approach is outside-in, that is *"start from the outside (the features, the problem domain), built your way in (the source code, the solution domain)"*

Let's have a look at the feature:

```
Feature: PayslipGenerator
  In order to pay employees
  As an HR administrator
  I want to be able to generate payslips

Scenario: User should be able to generate payslip for given employee input
  Given I am on the payslip generator page
  And I have valid employee details
  When I enter employee details
  And I generate payslip
  Then I should see payslip information

Scenario: User should see an error if he generates payslip for invalid employee details
  Given I am on the payslip generator page
  And I have invalid employee details
  When I enter employee details
  And I generate payslip
  Then I should see an error
```
We can build this literally step by step:

- *"Given I am on the payslip generator page"* 
  -- we write selenium tests that will fails because there is no page
  -- we go ahead and build PayslipGenerator.aspx in the PayslipGenerator project
  -- we run the step and it will pass

- *"And I have valid employee details"* 
  -- we write employee unit tests in PayslipGenerator.Tests and they fail because there is no Employee
  -- we generate *Api > Employee* model class in PayslipGenerator
  -- we run unit tests and they pass

- *"When I enter employee details"*
  -- we write selenium steps to interact with the page and they fail because there are no fields to interact with
  -- we create them in the .aspx page and hook them in PayslipGenerator.aspx.cs
  -- we run the tests and they pass

- *"And I generate payslip"*
  -- we add a button on the page to generate payslip
  -- we write unit tests for PayslipFactory and Payslip using rules provided to calculate tax
  -- tests will drive the implementation of the PayslipFactory and the Payslip model class
  -- we run the tests and they pass

- *"Then I should see payslip information"*
  -- we write selenium tests and they fail because there is now view of the payslip
  -- we add it to the .aspx page
  -- we run the tests and they pass

- *"Then I should see an error"*
  -- we write selenium tests and they fail because there is no validation
  -- we go ahead an implement the validation before generating the payslip in *isFormValid()*
  -- run tests and they pass

##Advantages of using BDD and TDD

- you will never run out of time for testing as you write the tests first!
- works great in Agile iterative development, CI, full-stack development etc.
- separation of concerns (the *what* in the feature, the *how* in the unit tests), easy to refactor (as long as the features and unit tests are passing)
- unit tests drive the implementation (model, api, factories etc.) 
- allows the entire business to add value by just writing plain text features
- offers feature coverage (how many features have been developed?)
- increases confidence in feature validation and verification







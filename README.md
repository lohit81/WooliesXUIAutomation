# WooliesXUIAutomation

# Description and Installation steps
This solution contains the simplest way to automate a web application (UI) by segregating the structure layer using Page Object Pattern framework. Like feature files pertaining scenarios, Steps definition is the Binding class of feature file. Page folder contains Page information and Helper folder contains the 

# Installation steps:
-	You need to have a Visual studio (2015/2017/2019) to write your classes, methods, features using .Net supported languages, here I chose C-harp.
-	Create a Unit project.
-	Create few folders as shown below like Feature, StepsDefinition, Pages, Helper classes.
-	Right click on project solution, Click Manage NuGet packages.
-	Install Specflow, here I used version 2.4.1.
-	Similarly install SpecRun, SpecRun.Specflow.
-	Install NUnit package.
-	Install ChromeDriver.
-	Install Selenium Webdriver, and WebDriver.Support.

More info, see Package.Config file.

![UIStructure](https://user-images.githubusercontent.com/4488811/104839026-cedff800-5912-11eb-8e24-45d434c0caf8.png)


# App.Config

Additional files like App.Config contains Information such as what environment we wish to execute our tests, here I mentioned as UAT for test illustration only. In the testConfig class, I mentioned about the base URL. There’s a way to Improve by mentioning URL in App config and call in testConfig class.
And additional field needs to be added in App.Config is <unitTestProvider name="SpecRun" /> to run the scenarios in Test Manager.

# Default.srProfile

This file contains information such as how many tries a solution should do if a case is failing, and also by providing a Filter tag, we can differentiate of scenarios based on tagging, for example, If you have tagged 6 scenarios as ‘@Regression” and 4 scenarios as “@Smoke”, and in this file if you add tag as <Filter>@Regression</Filter> then only scenarios marked with Regression will be execute rest will be ignored.

# Page Object Model with Selenium

The Page Object Model is a pattern, that is often used to abstract your Web UI with Selenium to easier automate it.

![POM](https://user-images.githubusercontent.com/4488811/104838993-93452e00-5912-11eb-9a5c-8930e72578f8.png)


# Page Object Model structure 
•	Feature folder contains the feature file(s) pertaining the scenarios in Gherkin language i.e. GIVEN, WHEN and THEN

Feature: ResponsiveDashboard

@Regression
Scenario: Visit first page and create a warrior
	Given I call the URL
	And I see covid information
	When I enter warrior name
	And I click button after entering name
	And I start the journey
	Then I can see a welcome label

# StepDefinition 

The StepDefinition folder pertains the class(es) with [Binding] attribute for scenarios such as
[Binding]
    class ResponsiveDashboardSteps : AbstractBaseStep
    {
        public static testConfig objConfig = new testConfig();
        public static string _baseURL;
        

        [Given(@"I call the URL")]
        public void GivenICallTheURL()
        {
            _baseURL = objConfig.getBaseUrl();
            driver.Navigate().GoToUrl(_baseURL);
        }
AbstractBaseClass carries Hooks such as [BeforeTestRun], [AfterTestRun] and [AfterTest] and respective methods. [BeforeTestRun] hooks set the browser driver object and keeps alive one instance for all tests, [AfterTestRun] will quit the driver once all tests are executed. [AfterTest] has a method if any test steps fails, it captures the screenshot(s) in Jpeg and saves in the TestReport folder.

# Pages 

This folder contains class(es) based on the features been implemented in the solution. Sometime we traverse from one page to another and with this kind of implementation, we can carry next page reference and consume each others methods, which means reduces the overhead of re-writing the methods. 
In the same folder, I have a class named “AbstarctPage”, which carries the Webdriver instance and we need it to pass through to each page classes to keep alive the driver instance by means of creating a constructor.

# Helper folder 

It has 2 classes testConfig and WebDriverWrapper. In testConfig class, fetches information from App.Config about environment to initiate.
WebDriverWrapper class is nothing but contains the different operational methods such as click an element, Select from drop down, send keys etc, also added explicit Wait until code finishes the execution.

# Build and Execute
It is very important to build your solution without any anomalies. Once successfully build, Select TestTest Explorer. It contains all the Test scenarios you listed. If you wish debug code, just choose run as Debug mode upon right clicking of the scenario. Else you can run all scenarios by pressing PLAY icon.

Note that since I am using freeware of SpecFlow, there’s an additional delay to invoke scenarios.

Another way to execute all scenario is via developer command prompt. This project solution has file named as “runtest.cmd”, it’s a powershell script file, first builds the project and then runs the SpecRun from the bin folder of the project. This complete UI-less approach to execute scenarios.

# Improvement
A very important section, as this solution is just for test illustration purpose only and requires improvements such as we can get and depict control id as
[FindsBy(How = How.Id, Using = "clickbutton")]
public IWebElement clickButton { get; set; } 

More Parameterization in Feature files, as of now I just added one scenarios, but if we have multiple scenarios and requires parameterization, we can define it as “double quotes” or by Scenario Outline.
We can also use Background property to define a repetitive tasks such as call a url or clicking a menu header etc.

For a complex feature, best is either use “TRY, CATCH” statement or “Using” keyword to cleanup garbage collection and release resources.
Likewise many more ways this solution can be improved. As IT is a CONTINUES IMPROVEMENT.

# Challenges
In this solution, the challenge is to keep track of SpecFlow libraries and its dependencies of others like chrome driver and MSBuild support files.

# SpecFlow - Cucumber for .NET
SpecFlow is a pragmatic BDD solution for .NET. It provides test automation for .NET (.NET Framework, .NET Core), based on the Gherkin specification language and integrates to Visual Studio.
•	Getting started using SpecFlow: https://specflow.org/getting-started/
•	Project website: https://www.specflow.org
•	Documentation: https://docs.specflow.org
•	Discussion group in our community: https://specflow.org/community
For queries please post them in our community discussion group.


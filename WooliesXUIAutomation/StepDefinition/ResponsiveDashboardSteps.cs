using System;
using TechTalk.SpecFlow;
using WooliesXUIAutomation.Pages;
using WooliesXUIAutomation.Utilities;

namespace WooliesXUIAutomation.StepDefinition
{
    [Binding]
    class ResponsiveDashboardSteps : AbstractBaseStep
    {
        public static testConfig objConfig = new testConfig();
        public static string _baseURL;
        public Initialisation objInit = new Initialisation(driver);

        [Given(@"I call the URL")]
        public void GivenICallTheURL()
        {
            _baseURL = objConfig.getBaseUrl();
            driver.Navigate().GoToUrl(_baseURL);
        }
        
        [Given(@"I see covid information")]
        public void GivenISeeCovidTitle()
        {
            driver.Title.Contains("THE GAME");
            objInit.covidInformation();
        }
        
        [When(@"I enter warrior name")]
        public void WhenIEnterName()
        {
            objInit.enterWarriorName();
        }

        [When(@"I click button after entering name")]
        public void WhenIClickButtonAfterEnteringName()
        {
            objInit.clickWarriorBtn();
        }

        [When(@"I start the journey")]
        public void WhenIStartTheJourney()
        {
            objInit.clickStartJourney();
        }


        [Then(@"I can see a welcome label")]
        public void ThenICanSeeAWelcomeLabel()
        {
            objInit.verifyWelcomeLabel();
        }
    }
}

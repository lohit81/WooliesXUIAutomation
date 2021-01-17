using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WooliesXUIAutomation.Pages
{
    class Initialisation : AbstractPage
    {
        protected readonly By covidIntroParagraph = By.XPath("//div[@class='block border']/p");
        protected readonly By enterWarriorTxt = By.Id("worrior_username");
        protected readonly By warriorBtn = By.Id("warrior");
        protected readonly By journeyBtn = By.Id("start");
        public static string strTestusername = "Gladiator";
        protected readonly By welcomeLabelTxt = By.Id("welcome_text");

        public Initialisation(IWebDriver driver) :
           base(driver)
        { }

        /// <summary>
        /// To get dashboard covid introduction paragraph
        /// </summary>
        /// <returns></returns>
        public Initialisation covidInformation()
        {
            //Covid introduction paragraph
            string strCovidIntro = driver.FindElement(covidIntroParagraph).Text;
            Assert.IsTrue(strCovidIntro.Contains("build the CURE team"), "Text not found");
            return new Initialisation(driver);
        }

        /// <summary>
        /// Enter Warrior Name
        /// </summary>
        /// <returns></returns>
        public Initialisation enterWarriorName()
        {
            // Enter name
            wrapper.clickElement(enterWarriorTxt, 1);
            wrapper.sendKeys(enterWarriorTxt, strTestusername, 1);
            Thread.Sleep(1000);

            return new Initialisation(driver);
        }

        /// <summary>
        /// Click Warrior button after entering warrior Name
        /// </summary>
        /// <returns></returns>
        public Initialisation clickWarriorBtn()
        {
            //Click Warrior button
            wrapper.clickElement(warriorBtn, 1);
            return new Initialisation(driver);
        }

        /// <summary>
        /// Start journey of test user name
        /// </summary>
        /// <returns></returns>
        public Initialisation clickStartJourney()
        {
            //Click Warrior button
            wrapper.clickElement(journeyBtn, 1);
            return new Initialisation(driver);
        }

        /// <summary>
        /// Verify Welcome name after start COVID test ourney
        /// </summary>
        /// <returns></returns>
        public Initialisation verifyWelcomeLabel()
        {
            //Verify that assigned user get welcoem label
            string strCovidIntro = driver.FindElement(welcomeLabelTxt).Text;
            Assert.IsTrue(strCovidIntro.Contains(strTestusername), "Text not found");

            return new Initialisation(driver);
        }

        
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace BddDemo.StepDefinitions
{
    [Binding]
    public class FacebookHomePageLoginStepDefinitions
    {
        IWebDriver driver;
        [Given(@"User Navigates to the facebook Home Page")]
        public void GivenUserNavigatesToTheFacebookHomePage()
        {
            driver=new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        [When(@"User Enters Test as UserName And Pass(.*) as Password")]
        public void WhenUserEntersTestAsUserNameAndPassAsPassword(int p0)
        {
          IWebElement Email=  driver.FindElement(By.Id("email"));
            Email.SendKeys("xyz@1234");
            IWebElement Password=driver.FindElement(By.Id("pass"));
            Password.SendKeys("dfghjk");
            
        }

        [When(@"Click on the Login Button")]
        public void WhenClickOnTheLoginButton()
        {
            driver.FindElement(By.Name("login")).Click();
           
        }

        [Then(@"Login should be unsuccesfull")]
        public void ThenLoginShouldBeUnsuccesfull()
        {
            Console.WriteLine(driver.Title);
            string expectedTitle = "Log in to Facebook";
            string actual=driver.Title;
           Assert.AreEqual(expectedTitle, actual);
            driver.Quit();
        }
    }
}

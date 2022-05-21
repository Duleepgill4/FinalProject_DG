using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject1.POMS;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

 // HOOK //

namespace FinalProject1.TestBase
{
    [Binding]
    public class TestBase
    {
        public static IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public TestBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void SetUp()
        {


            //set up baseURL
            driver = new ChromeDriver();
            _scenarioContext["webdriver"] = driver;
            string LogInURL = Environment.GetEnvironmentVariable("LogInURL");
            driver.Url = LogInURL;

        }

        [AfterScenario]
        public void Teardown()
        {
            //navigate to account and logout
            CloseDown LogOut = new CloseDown(driver);
            LogOut.LogOut();

        }
    }
}
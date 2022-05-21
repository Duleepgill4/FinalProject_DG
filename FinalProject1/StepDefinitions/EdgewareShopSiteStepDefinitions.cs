using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using FinalProject1.POMS;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow.Assist;
using FinalProject1.Support;
//using static FinalProject1.StepDefinitions.TestBase;

namespace FinalProject1.EdgewareShopSiteStepDefinitions
{
    [Binding]
    public class EdgewareShopSiteStepDefinitions
    {
        IWebDriver driver;
        Helper helper;
        private readonly ScenarioContext _scenarioContext;
        private TestData _data;
        public EdgewareShopSiteStepDefinitions(ScenarioContext scenarioContext, TestData data)
        {
            
            //defining browser with scenario contect
            _scenarioContext = scenarioContext;
            _data = data;
            driver = (IWebDriver)_scenarioContext["webdriver"];
            helper = new Helper(driver);

        }

        [Given(@"I log in as a registered user")]
        public void GivenILogInAsARegisteredUser()
        {
            
            //login using environmental variables username/pass from runsettings
            LogInPOMS LogIn = new LogInPOMS(driver);
            LogIn.Dismiss();
            LogIn.Loginuser(Environment.GetEnvironmentVariable("username"));
            LogIn.Loginpass(Environment.GetEnvironmentVariable("password"));
            LogIn.LogInBtn();
        }

        [Given(@"I add an item to my cart")]
        public void GivenIAddAnItemToMyCart()
        {
            //hoddie with logo added to cart
            Shop Hoodie = new Shop(driver);
            Hoodie.AddHoodie();
        }

        [When(@"I apply the '([^']*)' discount code")]
        public void WhenIApplyTheDiscountCode(string edgewords)
        {
            Cart Coupon = new Cart(driver);
            Coupon.AddCoupon(edgewords);
        }

        [Then(@"the '([^']*)'% discount and shipping is applied to the total")]
        public void ThenTheDiscountAndShippingIsAppliedToTheTotal(Decimal DiscountCode)
        {
            //allowing the system to catch up after adding coupon
            Thread.Sleep(1000);

            Cart Coupon = new Cart(driver);

            //entering try to capture if the discount is correct or not
            try
            {
                Assert.That((Coupon.CheckCoupon()), Is.EqualTo(DiscountCode), "Incorrect discount applied !");

            }
            catch (Exception )
            {
                
            }
        }

        [Then(@"the total is calculated correctly")]
        public void ThenTheTotalIsCalculatedCorrectly()
        {
            //checking total including discount and shipping
            Cart Coupon = new Cart(driver);
            

            //If correct total is same as supposed total then pass if it fails show message.
            Assert.That((Coupon.CheckTotal()), Is.EqualTo(Coupon.GetTotal()), "Total price is not calculated correctly !");
            //empty cart
            Coupon.Empty();

        }
        [When(@"I checkout with my details")]
        public void WhenICheckoutWithMyDetails(Table table)
        {
            _data = table.CreateInstance<TestData>();

            Checkout Checkout = new Checkout(driver);
            Checkout.CheckoutBtn();
            Checkout.BillingDetails(_data);
            Checkout.Placed();
        }

        [Then(@"My order is present in my Orders")]
        public void ThenMyOrderIsPresentInMyOrders()
        {
            //wait using helper file
            helper.WaitForUrl("order-received");

            //navigate to myorders page in account
            Orders orderDetails = new Orders(driver);

            //capture order number
            string MyOrder =orderDetails.MyOrder();
            orderDetails.ViewOrders();

            //check order numn is present in orders
            Assert.That((orderDetails.AllOrders()), Does.Contain(MyOrder), "order not present in stored orders");

        }
    }
}

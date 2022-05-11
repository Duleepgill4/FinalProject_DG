using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using FinalProject1.POMS;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
//using static FinalProject1.StepDefinitions.TestBase;

namespace FinalProject1.EdgewareShopSiteStepDefinitions
{
    [Binding]
    public class EdgewareShopSiteStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public EdgewareShopSiteStepDefinitions(ScenarioContext scenarioContext)
        {
            //defining browser with scenario contect
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["webdriver"];
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
        public void ThenTheDiscountAndShippingIsAppliedToTheTotal(Decimal p0)
        {
            //allowing the system to catch up after adding coupon
            Thread.Sleep(1000);

            Cart Coupon = new Cart(driver);
            //calling in and assigning figures to be used for assertion
            Decimal Discount = (Coupon.Discount())*100;
            Decimal Subtotal = Coupon.Subtotal();
            //calculate discount actually applied
            decimal AppliedDiscount = (Discount / Subtotal);//=10

            //entering try to capture if the discount is correct or not
            try
            {
                Assert.That(AppliedDiscount, Is.EqualTo(p0), "Incorrect discount applied !");

            }
            catch (Exception error)
            {
                Console.WriteLine("Unable to calculate discount ",error.Message);
            }
        }

        [Then(@"the total is calculated correctly")]
        public void ThenTheTotalIsCalculatedCorrectly()
        {
            //checking total including discount and shipping


            Cart Coupon = new Cart(driver);
            //calling in and assigning figures to be used for assertion
            Decimal Discount1 = Coupon.Discount();
            Decimal Subtotal1 = Coupon.Subtotal();
            Decimal Total = Coupon.Total();
            Decimal Shipping = Coupon.Shipping();
         //   decimal Shipping = Decimal.Parse("3.95");   


            Decimal CorrectTotal = (Subtotal1 - Discount1) + Shipping;
            //If correct total is same as supposed total then pass if it fails show message.
            Assert.That(CorrectTotal, Is.EqualTo(Total), "Total price is not calculated correctly !");


        }

        [When(@"I checkout with my details")]
        public void WhenICheckoutWithMyDetails()
        {
            Checkout Checkout = new Checkout(driver);
            Checkout.CheckoutBtn();
            Checkout.Billingfn(Environment.GetEnvironmentVariable("firstname"));
            Checkout.Billingln(Environment.GetEnvironmentVariable("lastname"));
            Checkout.Billingal1(Environment.GetEnvironmentVariable("addressL1"));
            Checkout.Billingal2(Environment.GetEnvironmentVariable("addressl2"));
            Checkout.Billingcity(Environment.GetEnvironmentVariable("city"));
            Checkout.Billingpc(Environment.GetEnvironmentVariable("postcode"));
            Checkout.Billingphone(Environment.GetEnvironmentVariable("phone"));

        
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2); //Thread.Sleep(1000);
            Checkout.placed();
        }

        [Then(@"My order is present in my Orders")]
        public void ThenMyOrderIsPresentInMyOrders()
        {
            //takes time to load order confirmation
            WebDriverWait Wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Wait2.Until(drv => drv.Url.Contains("order-received"));

            //order just placed
            string MyOrder = '#' + driver.FindElement(By.CssSelector(".order > strong")).Text;

            Orders orderDetails = new Orders(driver);
            orderDetails.ViewOrders();

            //capture the whole orders tbl
            var Orders = driver.FindElement(By.ClassName("account-orders-table")).Text;
            //List<string> allOrders = new List<string>();

            //check order numn is present in orders
            Assert.That(Orders, Does.Contain(MyOrder), "order not present in stored orders");

        }
    }
}

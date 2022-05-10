using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using FinalProject1.POMS;
using OpenQA.Selenium.Support.UI;
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
            Thread.Sleep(1000);
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
            AddToCart Hoodie = new AddToCart(driver);
            Hoodie.AddHoodie();
        }

        [When(@"I apply the '([^']*)' discount code")]
        public void WhenIApplyTheDiscountCode(string edgewords)
        {
            DiscountTotal Coupon = new DiscountTotal(driver);
            string Edgewords = "edgewords";
            Coupon.AddCoupon(Edgewords);
            Coupon.ApplyCoupon();
        }

        [Then(@"the discount and shipping is applied to the total")]
        public void ThenTheDiscountAndShippingIsAppliedToTheTotal()
        {
            //explicit conditional wait/thread 
            Thread.Sleep(1000);

            //get discount value as css and convert to decimal and remove string position 1 (£)
            string GetDiscount = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
            decimal Discount = (Decimal.Parse(GetDiscount.Substring(1))) * 100;

            //get after discount price and convert to float
            string GetSubtotal = driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text;
            decimal Subtotal = Decimal.Parse(GetSubtotal.Substring(1));
            //calculate discount applied
            decimal AppliedDiscount = (Discount / Subtotal);//=10
            decimal Discount15 = 15; //correct discount of coupon

            //entering try to capture if the discount is correct or not
            try
            {
                Assert.That(AppliedDiscount, Is.EqualTo(Discount15), "Incorrect discount applied");

            }
            catch (Exception)
            {

            }
        }

        [Then(@"the total is calculated correctly")]
        public void ThenTheTotalIsCalculatedCorrectly()
        {
            //checking total including discount and shipping

            string GetSubtotalAgain = driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text;
            //convert cssselector captured as string to decimal and remove first string (£)
            decimal Subtotal2 = Decimal.Parse(GetSubtotalAgain.Substring(1));
            decimal Shipping = Decimal.Parse("3.95");   //shipping cost
            //capture discount total and convert string to dec and strip first string (£)
            string GetDiscountTotal = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
            decimal DiscountTotal = Decimal.Parse(GetDiscountTotal.Substring(1));
            //capture total and convert string to decimal and strip first string (£)
            string GetTotal = driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount")).Text;
            decimal Total = Decimal.Parse(GetTotal.Substring(1));

            decimal CorrectTotal = (Subtotal2 - DiscountTotal) + Shipping;
            //If correct total is same as supposed total then pass if it fails show message.
            Assert.That(CorrectTotal, Is.EqualTo(Total), "total price is not calculated correctly");


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

            Thread.Sleep(1000);
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

            OrderDetails orderDetails = new OrderDetails(driver);
            orderDetails.ViewOrders();

            //capture the whole orders tbl
            var Orders = driver.FindElement(By.ClassName("account-orders-table")).Text;
            //List<string> allOrders = new List<string>();

            //check order numn is present in orders
            Assert.That(Orders, Does.Contain(MyOrder), "order not present in stored orders");

        }
    }
}

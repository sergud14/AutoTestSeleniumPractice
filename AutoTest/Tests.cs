namespace AutoTest
{
    public class Tests:BaseTest
    {
        [Test, Order(1)]

        public void PerformAuthentication()
        {
            var mainPage = new MainPage(driver);
            var authenticationPage = mainPage.OpenAuthenticationPage();
            Assert.NotNull(authenticationPage.SignIn());
        }

        [Test, Order(2)]
        public void GoToDressesPage()
        {
            var myAccountPage = new MyAccountPage(driver);
            Assert.NotNull(myAccountPage.OpenDressesPage());
        }

        [Test, Order(3)]
        public void GoToCasualDressesPage()
        {
            var dressesPage = new DressesPage(driver);
            Assert.NotNull(dressesPage.OpenCasualDressesPage());
        }

        [Test, Order(4)]
        public void GoToPrintedDressesPage()
        {
            var casualDressesPage = new CasualDressesPage(driver);
            Assert.NotNull(casualDressesPage.OpenPrintedDressesPage());
        }

        [Test, Order(5)]
        public void ChoosePrintedDress()
        {
            var printedDressPage = new PrintedDressPage(driver);
            printedDressPage.SelectSize();
            Assert.NotNull(printedDressPage.AddToCart());
        }

        [Test, Order(6)]
        public void GoToShoppingCartSummaryPage()
        {
            var orderInfoModalWindow = new OrderInfoModalWindow(driver);
            Assert.NotNull(orderInfoModalWindow.OpenShoppingCartSummaryPage());
        }

        [Test, Order(7)]
        public void GoToAddressTab()
        {
            var shoppingCartSummaryPage = new ShoppingCartSummaryPage(driver);
            Assert.IsTrue(shoppingCartSummaryPage.OpenAddressTab());
        }

        [Test, Order(8)]
        public void GoToShippingTab()
        {
            var shoppingCartSummaryPage = new ShoppingCartSummaryPage(driver);
            Assert.IsTrue(shoppingCartSummaryPage.OpenShippingTab());
        }

        [Test, Order(9)]
        public void GoToPaymentTab()
        {
            var shoppingCartSummaryPage = new ShoppingCartSummaryPage(driver);
            Assert.IsTrue(shoppingCartSummaryPage.OpenPaymentTab());
        }

    }
}

using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Test.Entities
{
    [TestClass]
    public class OrderTest
    {
        private Customer _customer;
        private Order _order;

        private Product _mouse;
        private Product _teclado;
        private Product _monitor;
        private Product _notebook;
        private Product _chair;
        public OrderTest()
        {
            var name = new Name("Capitão", "América");
            var email = new Email("vingadores@marvel.com");
            var document = new Document("123123213");
            var address = new Address("123A", "091800", "New York", "NY", EAddressType.Shipping);
            _customer = new Customer(name, document, email);
            _order = new Order(_customer);

            _mouse = new Product("Mouse Logitech", "Excelente mouse", "base64", 25, 10);
            _teclado = new Product("Teclado windows", "Excelente Teclado", "base64", 18, 150);
            _chair = new Product("Cadeira Gamer", "Excelente Cadeira", "base64", 20, 100);
            _notebook = new Product("Notebook Vaio", "Excelente Notebook", "base64", 2, 100);
            _monitor = new Product("Monitor Samsung", "Excelente Monitor", "base64", 20, 100);
        }

        //red, green, refactory
        [TestMethod]
        public void Should_Create_Valid_Order()
        {
            Assert.IsTrue(_order.Valid);
        }

        [TestMethod]
        public void Should_Status_Be_Created_When_Order_Created()
        { 
            Assert.IsTrue(_order.Valid);
            Assert.AreEqual(_order.Status, EOrderStatus.Created);
        }

        [TestMethod]
        public void Should_Return_Two_When_Added_Two_Valid_Items()
        {  
            _order.AddItem(_mouse, 1);
            _order.AddItem(_teclado, 4);

            Assert.IsTrue(_order.Valid);
            Assert.AreEqual(_order.Items.Count, 2);
        }

        [TestMethod]
        public void Should_Return_Five_Items_When_Purchased_Five_Items_Of_Ten()
        { 
            _order.AddItem(_mouse, 5);

            Assert.IsTrue(_order.Valid);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        [TestMethod]
        public void Should_Return_A_Number_When_Order_Placed()
        {
            _order.AddItem(_mouse, 5);
            _order.Place();

            Assert.IsTrue(_order.Valid);
            Assert.AreNotEqual(_order.Number, string.Empty);
        }
        [TestMethod]
        public void Should_Return_Status_Paid_When_Order_Is_Paid()
        {
            _order.Pay();
            Assert.IsTrue(_order.Valid);
            Assert.AreEqual(_order.Status, EOrderStatus.Paid);
        }
    }
}

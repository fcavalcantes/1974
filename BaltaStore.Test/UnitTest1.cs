using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Capitão", "América");
            var email = new Email("vingadores@marvel.com");
            var document = new Document("123123213");
            var address = new Address("123A", "091800","New York", "NY", EAddressType.Shipping);
            var customer = new Customer(name, document, email);
            customer.AddAddress(address);

            var mouse = new Product("Mouse Logitech", "Excelente mouse", "base64", 25, 10);
            var teclado = new Product("Teclado windows", "Excelente Teclado", "base64", 253, 15);
            var impressora = new Product("Impressora HP", "Excelente Impressora", "base64", 100, 100);

            var order = new Order(customer);
            // order.AddItem(new OrderItem(mouse, 5));
            // order.AddItem(new OrderItem(teclado, 10));
            // order.AddItem(new OrderItem(impressora, 15));

            //Realiza o pedido
            order.Place();

            var valid = order.Valid;

            //Paga o pedido
            order.Pay();

            //Envia o pedido
            order.Ship();

            //Cancela o pedido
            order.Cancel();
            Assert.IsTrue(true);
        }
    }
}

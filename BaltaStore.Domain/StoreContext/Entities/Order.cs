using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Enums;

using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order:Entity
    {
      private readonly IList<OrderItem> _items;
      
      private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate =  DateTime.Now;
            Status = EOrderStatus.Created;
            _items =  new List<OrderItem>();
            _deliveries =  new List<Delivery>();
            
        }
        public Customer Customer { get; private set; }
        public string Number { get;private set; }  
        public DateTime CreateDate {get;private set;}
        public EOrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Items  => _items.ToArray();
        
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,7).ToUpper();

              AddNotifications(
                new Contract().Requires()
                .IsGreaterThan(_items.Count, 0, "OrderItem.Itens", "Este pedido não possui itens.")                
            );
        }
        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }
        public void AddItem(Product product, decimal quantity)
        {
            AddNotifications(
                new Contract().Requires().IsGreaterThan(product.QuantityOnHand, quantity, "Product.Quantity", "Produto não têm no estoque")
            );
            var item = new OrderItem(product, quantity);
            _items.Add(item);            
        }
  
        public void Pay()
        {
            //Pedido pago, manda enviar
            Status = EOrderStatus.Paid;           
        }

        public void Ship()
        { 
            // Manda entregar
            var delivery = new Delivery(DateTime.Now.AddDays(5));
            delivery.Ship();

            //Adiciona a entrega ao pedido
            _deliveries.Add(delivery);
        }
        public void Cancel()
        { 
           Status =  EOrderStatus.Canceled;
           _deliveries.ToList().ForEach(d=>d.Cancel());
        }
    }
}
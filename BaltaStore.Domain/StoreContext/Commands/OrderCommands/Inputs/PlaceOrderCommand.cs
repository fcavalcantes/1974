using System;
using System.Collections.Generic;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class PlaceOrderCommand: Notifiable, ICommand
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get;  set; }  
        public bool Validate()
        {
             AddNotifications(
                new Contract().Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador de cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "OrderItems", "Não foi encontrado item no pedido")
            );

            return Valid;
        }
    }
}
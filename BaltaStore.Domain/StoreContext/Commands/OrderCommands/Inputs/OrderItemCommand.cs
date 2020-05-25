using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class OrderItemCommand: Notifiable, ICommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get;  set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
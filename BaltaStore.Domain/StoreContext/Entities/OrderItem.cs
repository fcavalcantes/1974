
using BaltaStore.Shared.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            AddNotifications(
                new Contract().Requires()
                .HasMinLen(quantity.ToString(), 1, "OrderItem.Quantity", "Deve ser escolhido pelo menos um item.")
                .IsNotNull(product, "OrderItem.Product", "Um produto é obrigatório")
            );

            product.DecreaseQuantity(quantity);
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
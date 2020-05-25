using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Product:Entity
    {
        public Product(
        string title,
        string description,
        string image,
        decimal price,
        decimal quantityOnHand
    )
    {
        Title = title;
        Description = description;
        Image = image;
        Price = price;
        QuantityOnHand = quantityOnHand;
    }
        public string Title { get; set; }
        public string Description { get; set; }  
        public string Image {get; set;}
        public decimal Price { get; set; }

        public decimal QuantityOnHand { get; set; }

        public override string ToString() => Title;

        public void DecreaseQuantity(decimal quantity)
        {
            if(this.QuantityOnHand > quantity)
                QuantityOnHand -= quantity;
        }
    }
}
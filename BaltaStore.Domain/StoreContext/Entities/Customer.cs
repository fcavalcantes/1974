using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Entities;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer: Entity
    {
      private readonly IList<Address> _addresses;
        public Customer(Name name, Document document, Email email)
        {
          Name = name;  
          Document = document;
          Email = email;
          _addresses = new List<Address>();

          AddNotifications(name, document, email);
    
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; } 
        public Email Email { get; private set; }
        public IReadOnlyCollection<Address> Addresses =>  _addresses.ToArray();

        public void AddAddress(Address address)
        {
          _addresses.Add(address);
        }
    }
}
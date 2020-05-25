using BaltaStore.Domain.StoreContext.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Address:Notifiable
    {
        public Address(string number, string zipCode, string city, string state, EAddressType typeAddress)
         {
            Number = number; 
            ZipCode = zipCode;
            City = city;
            State = state;
            Type = typeAddress;

            AddNotifications(
            new Contract().Requires().IsNotNullOrEmpty(Number, "Number", "Informar o número")
            .IsNotNullOrEmpty(ZipCode, "ZipCode", "Informar o CEP")
            );
        }

        public string ZipCode { get; private set; } 
        public string City { get; private set; } 
        public string State { get; private set; } 
        public string Number { get; private set; }         
        public EAddressType Type { get; private set; }

        public override string ToString()
        {
            return $"{ZipCode}, {Number} - {City}/{State}";
        } 

     } 
     
}
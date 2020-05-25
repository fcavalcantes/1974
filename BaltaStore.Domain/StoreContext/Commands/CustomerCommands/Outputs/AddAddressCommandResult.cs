using System;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Outputs
{
    public class AddAddressCommandResult
    {
        public AddAddressCommandResult()
        { 
        }
        public AddAddressCommandResult(Guid id, string firstName, string lastName, string document, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

    }
}
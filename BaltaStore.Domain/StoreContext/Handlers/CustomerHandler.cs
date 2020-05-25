using System;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        ICustomerRepository _customerRepository;
        public CustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            var name = new Name("Capitão", "América");
            var email = new Email("vingadores@marvel.com");
            var document = new Document("123123213");
            var address = new Address("123A", "091800", "New York", "NY", EAddressType.Shipping);
            var customer = new Customer(name, document, email);


            AddNotifications(name, email, document, address, customer);

            if (_customerRepository.CheckEmail(email.EmailAddress))
                AddNotification("Email", "Email informado já está em uso.");
            if (_customerRepository.CheckDocument(document.Number))
                AddNotification("CPF", "CPF informado já está em uso.");

                if(Invalid)
                return new CommandResult(false, "Não foi possível completar a operação.", Notifications);


                _customerRepository.Save(customer);
            
            return new CommandResult(true, "Bem vindo",new {id =  customer.Id, Name = name.ToString()});
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            return new CommandResult(true, "Sucesso",new {OK=true});
        }
    }
}
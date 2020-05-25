using BaltaStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand: Notifiable, ICommand
    {
         public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Document { get;  set; } 
        public string Email { get;  set; }

      
        public bool Validate()
        {
             AddNotifications(
                new Contract().Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O primeiro nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "Name.FirstName", "O primeiro nome deve conter no máximo 30 caracteres")
                .IsNotNullOrEmpty(FirstName, "Name.FirstName", "O nome deve ser informado")
                .IsEmail(Email, "Email", "Email inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );

            return Valid;
        }
    }
}
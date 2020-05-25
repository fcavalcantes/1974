using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string email)
        {
            EmailAddress = email;
            AddNotifications(
                new Contract().Requires()
                .IsNotNullOrEmpty(email, "Email.Email", "Email deve ser informado")
                .IsEmail(email, "Email.Email", "Email inválido")
            );
        }

        public string EmailAddress { get; private set; }

        public override string ToString()
        {
            return EmailAddress;
        }

    }
}
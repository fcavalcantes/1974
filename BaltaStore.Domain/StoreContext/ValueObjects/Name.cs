using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(
                new Contract().Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O primeiro nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "Name.FirstName", "O primeiro nome deve conter no máximo 30 caracteres")
                .IsNotNullOrEmpty(FirstName, "Name.FirstName", "O nome deve ser informado")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
 
    }
}
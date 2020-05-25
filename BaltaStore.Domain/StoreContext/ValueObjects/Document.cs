using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Document:Notifiable
    {
        public Document(string doc)
        {
            Number = doc; 

               AddNotifications(
                new Contract().Requires()
                .IsNotNullOrEmpty(Number, "Document.Number", "Document deve ser informado")
                .IsTrue(ValidateDocument(Number), "Document.number", "Documento inválido")
            );
        }

        public string Number { get; private set; } 
     
        public override string ToString()
        {
            return Number;
        }

        private bool ValidateDocument(string docNum)
        {
            //TO DO
            if( string.IsNullOrEmpty(docNum))
                return false;
            if( docNum.Length < 6)
              return false;

              return true;
        }
    }
}
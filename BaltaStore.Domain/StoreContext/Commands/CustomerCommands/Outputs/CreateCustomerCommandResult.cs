using System;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult:  ICommandResult
    {
        public CreateCustomerCommandResult(){}
        public CreateCustomerCommandResult(bool result, string message, object data)
        {
            Result = result;
            Message = message;
            Data = data;
        }

        public bool Result { get;  set; }
        public string Message { get;  set; } 
        public object Data { get;  set; }

    }
}
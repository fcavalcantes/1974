using System;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Outputs
{
    public class CommandResult:  ICommandResult
    {
        public CommandResult(){}
        public CommandResult(bool result, string message, object data)
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
namespace BaltaStore.Shared.Commands
{
    public interface ICommandResult
    { 
        bool Result {get;set;}
        string Message {get;set;}
        object Data {get;set;}
    }
}
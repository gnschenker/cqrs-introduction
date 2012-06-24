namespace CqrsIntroduction
{
    public class CommandResult
    {
        public CommandResultTypes ResultType { get; set; }
             
    }

    public enum CommandResultTypes
    {
        Undefined = 0,
        Success=1,
        ValidationFailed,

        Error = -1
    }
}
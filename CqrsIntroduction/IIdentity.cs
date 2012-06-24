namespace CqrsIntroduction
{
    public interface IIdentity
    {
        string GetId();
    }

    public interface ICqrsMessage { }

    public interface ICommand<out TIdentity> : ICqrsMessage
        where TIdentity : IIdentity
    {
        TIdentity Id { get; }
    }

    public interface IEvent<out TIdentity> : ICqrsMessage
        where TIdentity : IIdentity
    {
        TIdentity Id { get; }
    }
}

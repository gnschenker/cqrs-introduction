namespace CqrsIntroduction
{
    public interface IAggregateFactory
    {
        void Dispatch(ICommand<IIdentity> c);
    }
}

using System;
using CqrsIntroduction;

namespace TestClient
{
    // this is a fake for the real implementation which uses the command pipeline
    // as described in part 5 of the post series
    internal static class Bus
    {
        private static readonly IAggregateFactory aggregateFactory = new AggregateFactory();

        public static void Send(ICommand<IIdentity> command, Action<CommandResult> onSuccess)
        {
            aggregateFactory.Dispatch(command);
            onSuccess(new CommandResult {ResultType = CommandResultTypes.Success});
        }
    }
}
using System;
using System.Collections.Generic;

namespace CqrsIntroduction
{
    public class AggregateFactory : IAggregateFactory
    {
        public void Dispatch(ICommand<IIdentity> command)
        {
            var id = command.Id;
            var events = LoadEventsFromEventStore(id);
            var observer = GetObserver();

            var taskId = id as TaskId;
            if (taskId != null)
            {
                var state = new TaskAggregateState(events);
                var agg = new TaskAggregate(state, observer);
                agg.Execute(command);
                return;
            }

            // other aggregate types
            // ...

            throw new Exception(
                string.Format("Unexpected aggregate id type '{0}'",
                              id.GetType()));
        }

        private IEnumerable<IEvent<IIdentity>> LoadEventsFromEventStore(IIdentity id)
        {
            return new IEvent<IIdentity>[0];    // implementation will follow in future post
        }

        private Action<IEvent<IIdentity>> GetObserver()
        {
            return e => { };    // implementation will follow in future post
        }
    }
}

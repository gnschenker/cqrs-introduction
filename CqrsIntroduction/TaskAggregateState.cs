using System.Collections.Generic;

namespace CqrsIntroduction
{
    public class TaskAggregateState
    {
        public TaskAggregateState(IEnumerable<IEvent<IIdentity>> events)
        {
            foreach (var e in events)
                Apply(e);
        }

        public int Version { get; set; }

        public void Apply(object @event)
        {
            //...
        }
    }
}

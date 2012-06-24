using System;

namespace CqrsIntroduction
{
    public class TaskAggregate
    {
        private TaskAggregateState state;
        private Action<IEvent<IIdentity>> observer;

        public TaskAggregate(TaskAggregateState state, Action<IEvent<IIdentity>> observer)
        {
            this.state = state;
            this.observer = observer;
        }

        public void Execute(ICommand<IIdentity> command)
        {
            RedirectToWhen.Invoke(this, command);
        }

        public void When(ScheduleNewTask c)
        {
            if (state.Version > 0)
                throw new Exception("Cannot create the same aggregate twice.");

            var e = new NewTaskScheduled
            {
                Id = c.Id,
                TaskName = c.TaskName,
                Instructions = c.Instructions,
                DueDateTime = c.DueDateTime,
                CandidateIds = c.CandidateIds,
                AnimalIds = c.AnimalIds
            };
            Apply(e);
        }

        private void Apply(IEvent<IIdentity> @event)
        {
            state.Apply(@event);
            observer(@event);
        }
    }
}

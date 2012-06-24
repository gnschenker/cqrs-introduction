namespace CqrsIntroduction
{
    public interface ICommandAction<in TCommand>
    {
        void Handle(TCommand command);
    }

    public class ScheduleNewTaskCommandAction : ICommandAction<ScheduleNewTask>
    {
        private readonly IAggregateFactory aggregateFactory;

        public ScheduleNewTaskCommandAction(IAggregateFactory factory)
        {
            aggregateFactory = factory;
        }

        public void Handle(ScheduleNewTask command)
        {
            aggregateFactory.Dispatch(command);
        }
    }
}

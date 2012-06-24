using System;

namespace CqrsIntroduction
{
    public class ScheduleNewTask : ICommand<TaskId>
    {
        public TaskId Id { get; set; }
        public string TaskName { get; set; }
        public string Instructions { get; set; }
        public DateTime DueDateTime { get; set; }
        public Guid[] CandidateIds { get; set; }
        public Guid[] AnimalIds { get; set; }
    }

}

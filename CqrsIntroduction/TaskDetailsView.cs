using System;

namespace CqrsIntroduction
{
    public class TaskDetailsView
    {
        public TaskId Id { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDateTime { get; set; }
        public string Instructions { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public Guid[] CandidateIds { get; set; }
        public Guid[] AnimalIds { get; set; }
    }
}

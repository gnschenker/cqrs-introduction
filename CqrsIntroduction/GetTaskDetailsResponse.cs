using System;

namespace CqrsIntroduction
{
    public class GetTaskDetailsResponse
    {
        public string TaskName { get; set; }
        public DateTime DueDateTime { get; set; }
        public string Instructions { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public NameId[] Candidates { get; set; }
        public AnimalInfo[] Animals { get; set; }
    }

    public class AnimalInfo
    {
        public Guid Id { get; set; }
        public string AnimalIdentifier { get; set; }
        // more properties
    }
}

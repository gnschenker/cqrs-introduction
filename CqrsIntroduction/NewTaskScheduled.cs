using System;
using System.Runtime.Serialization;

namespace CqrsIntroduction
{
    [DataContract(Namespace="VMS")]
    public class NewTaskScheduled : IEvent<TaskId>
    {
        [DataMember(Order=1)] public TaskId Id { get; set; }
        [DataMember(Order=2)] public string TaskName { get; set; }
        [DataMember(Order=3)] public string Instructions { get; set; }
        [DataMember(Order=4)] public DateTime DueDateTime { get; set; }
        [DataMember(Order=5)] public Guid[] CandidateIds { get; set; }
        [DataMember(Order=6)] public Guid[] AnimalIds { get; set; }
    }
}

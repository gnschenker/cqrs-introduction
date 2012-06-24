using System;

namespace CqrsIntroduction
{
    public class GetTaskDetailsQuery
    {
        public Guid TaskId { get; set; }
    }
}

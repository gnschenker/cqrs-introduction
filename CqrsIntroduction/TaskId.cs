using System;

namespace CqrsIntroduction
{
    public class TaskId : IIdentity
    {
        public string GetId()
        {
            return Id.ToString();
        }

        public Guid Id { get; private set; }
        public string Tag { get { return "task"; } }

        public TaskId(Guid id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Tag, Id.ToString().Substring(0, 6));
        }
    }
}

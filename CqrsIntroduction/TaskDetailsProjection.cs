namespace CqrsIntroduction
{
    public class TaskDetailsProjection
    {
        private IAtomicWriter<TaskId, TaskDetailsView> writer;

        public TaskDetailsProjection(IAtomicWriter<TaskId, TaskDetailsView> writer)
        {
            this.writer = writer;
        }

        public void When(NewTaskScheduled e)
        {
            writer.Add(e.Id, new TaskDetailsView { 
                Id = e.Id,
                TaskName = e.TaskName,
                Instructions = e.Instructions,
                DueDateTime = e.DueDateTime,
                TaskStatus = TaskStatus.Draft,
                CandidateIds = e.CandidateIds,
                AnimalIds = e.AnimalIds
            });
        }

        public void When(TaskPublished e)
        {
            writer.UpdateOrThrow(e.Id, view => view.TaskStatus = TaskStatus.Published);
        }

        // more code
    }
}

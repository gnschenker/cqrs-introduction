namespace CqrsIntroduction
{
    public enum TaskStatus
    {
        Undefined = 0,
        Draft,
        Published,
        Accepted,
        Started,
        Completed,
        Cancelled
    }
}

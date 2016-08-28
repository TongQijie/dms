namespace Dade.Dms.Data.Jobs
{
    public interface IJob
    {
        string Name { get; }

        int Interval { get; }

        void Execute();
    }
}

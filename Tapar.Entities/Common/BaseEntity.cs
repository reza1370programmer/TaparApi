namespace Tapar.Data.Common
{
    public interface IEntity
    {
    }

    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }

    public abstract class SharedEntity : BaseEntity<long>
    {
        public DateTime? cDate { get; set; } = null;
        public DateTime? modifiedDate { get; set; } = null;
        public long? modifiedUserId { get; set; } = null;
        public Status status { get; set; } = Status.WaitingForApprove;
    }
    public enum TimeEnum
    {
        AM = 1, PM = 2, AM_PM = 3, NoTime = 4
    }
    public enum Status
    {
        Approved = 1, WaitingForApprove = 2, NotApproved = 3
    }
}

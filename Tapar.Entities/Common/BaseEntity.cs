namespace Tapar.Data.Common
{
    public interface IEntity
    {
    }

    public  abstract  class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }

    public abstract class SharedEntity : BaseEntity<long>
    {
        public DateTime? cDate { get; set; } = null;
        public long?  cUserId { get; set; } = null;
        public DateTime? modifiedDate { get; set; } = null;
        public long? modifiedUserId { get; set; } = null;
        public DateTime? approvedDate { get; set; } = null;
        public long? approvedUserId { get; set; } = null;
        public DateTime? deactivatedDate { get; set; } = null;
        public long? deactivatedUserId { get; set; } = null;
        public string? deactivatedDescription { get; set; } = null;
        public DateTime? deletedDate { get; set; } = null;
        public long? deletedUserId { get; set; } = null;
    }
    public enum TimeEnum
    {
        AM = 1, PM = 2, AM_PM = 3, NoTime = 4
    }

}

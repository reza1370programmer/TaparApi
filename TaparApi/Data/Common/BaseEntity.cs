namespace TaparApi.Data.Common
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
        public DateTime? cDate { get; set; }
        public long?  cUserId { get; set; }
        public DateTime? modifiedDate { get; set; }
        public long? modifiedUserId { get; set; }
        public DateTime? approvedDate { get; set; }
        public long? approvedUserId { get; set; }
        public DateTime? deactivatedDate { get; set; }
        public long? deactivatedUserId { get; set; }
        public string? deactivatedDescription { get; set; }
        public DateTime? deletedDate { get; set; }
        public long? deletedUserId { get; set; }
    }

}

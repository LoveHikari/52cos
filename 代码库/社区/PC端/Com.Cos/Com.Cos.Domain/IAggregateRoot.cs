namespace Com.Cos.Domain
{
    /// <summary>
    /// 实体接口，所有实体都应该实现这个接口
    /// </summary>
    public interface IAggregateRoot
    {
        int Id { get; }
    }
}

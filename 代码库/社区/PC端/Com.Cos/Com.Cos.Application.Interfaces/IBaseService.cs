using Com.Cos.Domain;

namespace Com.Cos.Application.Interfaces
{
    public interface IBaseService<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {

    }
}
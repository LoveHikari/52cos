using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 兑换回复评论表仓储
    /// </summary>
    public class ExchangeReplyRepository:BaseRepository<ExchangeReply>, IExchangeReplyRepository
    {
        public ExchangeReplyRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
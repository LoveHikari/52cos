using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 合作回复评论表仓储
    /// </summary>
    public class CooperationReplyRepository:BaseRepository<CooperationReply>,ICooperationReplyRepository
    {
        public CooperationReplyRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
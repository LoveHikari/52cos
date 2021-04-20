using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    /// <summary>
    /// 邮费表业务
    /// </summary>
    public class PostageService:BaseService<Postage>, IPostageService
    {
        public PostageService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 获得邮费
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetPostageAsync()
        {
            return (await this.PostageRepository.FindAsync(p => true)).Cost;
        }
    }
}
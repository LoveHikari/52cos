using System.Collections;
using System.Linq;
using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using System.Collections.Generic;
using Com.Cos.Application.DTO;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 分享表仓储
    /// </summary>
    public class ExchangeRepository : BaseRepository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository(IDbContext nContext) : base(nContext)
        {
            
        }
        
    }
}
using System.Threading.Tasks;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 短信验证码表业务逻辑接口
    /// </summary>
    public interface ILoginCodeService : IBaseService<LoginCode>
    {
        /// <summary>
        /// 添加验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns>添加成功返回true</returns>
        Task<bool> AddAsync(string phone,string code);
        /// <summary>
        /// 查询验证码，满足条件返回true
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns>满足条件返回true</returns>
        Task<bool> FindAsync(string phone,string code);
    }
}
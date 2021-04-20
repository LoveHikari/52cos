using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 后台用户表业务接口
    /// </summary>
    public interface IAdminMemberService:IBaseService<AdminMember>
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        AdminMemberDto Find(string userName, string password);
    }
}
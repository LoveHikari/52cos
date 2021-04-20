using System;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 用户表业务接口
    /// </summary>
    public interface IMemberService : IBaseService<Member>
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        Task<MemberDto> FindAsync(int id);
        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="portrait">头像地址</param>
        /// <returns>是否更新成功</returns>
        Task<bool> UpdatePortraitAsync(int id, string portrait);
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="type">注册类型，phone、QQ、wechat</param>
        /// <param name="userName">用户名，手机注册时为手机号，QQ注册时为openid</param>
        /// <param name="lastIp">注册ip</param>
        /// <param name="pwd">密码</param>
        /// <param name="nickname">昵称</param>
        /// <param name="gender">性别</param>
        /// <param name="figureurl">头像</param>
        /// <returns>用户id</returns>
        Task<int> AddAsync(string type, string userName, string lastIp, string pwd = "", string nickname = "", string gender = "", string figureurl = "/Upload/Portrait/1.jpg");

        /// <summary>
        /// 是否已经存在用户
        /// </summary>
        /// <param name="type">注册类型，phone、QQ、wechat</param>
        /// <param name="userName">用户名，手机注册时为手机号，QQ注册时为openid</param>
        /// <returns>返回用户id</returns>
        Task<int> ExistAsync(string type, string userName);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns>修改成功返回true</returns>
        Task<bool> UpdatePasswordAsync(string phone, string pwd);
        /// <summary>
        /// 获得用户id
        /// </summary>
        /// <param name="type">注册类型，phone、QQ、wechat</param>
        /// <param name="userName">用户名，手机注册时为手机号，QQ注册时为openid</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户id</returns>
        Task<int> FindAsync(string type, string userName, string pwd);

        /// <summary>
        /// 获得应交押金
        /// </summary>
        /// <returns></returns>
        Task<int> GetDepositAsync(int id, int value);

        /// <summary>
        /// 更新融云token
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="rongToken">新的token</param>
        /// <returns></returns>
        Task<bool> UpdateRongTokenAsync(int userId, string rongToken);
        /// <summary>
        /// 更新个性信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(MemberDto dto);

        /// <summary>
        /// 获得用户数
        /// </summary>
        /// <returns></returns>
        int GetUserCount(DateTime? dateTime = null);

        /// <summary>
        /// 获得会员数
        /// </summary>
        /// <returns></returns>
        int GetUserVipCount(DateTime? dateTime = null);
    }
}
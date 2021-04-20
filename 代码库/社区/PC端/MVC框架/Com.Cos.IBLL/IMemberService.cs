using System.Security.Claims;
using Com.Cos.Models;

namespace Com.Cos.IBLL
{
    public interface IMemberService:IBaseService<Member>
    {
        ClaimsIdentity CreateIdentity(Member member, string authenticationType);
        /// <summary>
        /// 根据邮箱或手机号获得实体
        /// </summary>
        /// <param name="userName">手机号或邮箱</param>
        /// <returns></returns>
        Member Find(string userName);
        /// <summary>
        /// 根据指定字段的值是否存在
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">值</param>
        /// <returns>是否存在</returns>
        bool Exist(string field, string value);

        /// <summary>
        /// 根据id获得实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Member Find(int id);
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <param name="id">userid</param>
        /// <param name="pwd">加密后的密码</param>
        /// <returns></returns>
        Member Find(int id, string pwd);
    }
}
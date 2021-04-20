using System.Security.Claims;
using Com.Cos.IBLL;
using Com.Cos.Models;
using Microsoft.AspNet.Identity;
using Com.Cos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Com.Cos.Common;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 用户业务类
    /// </summary>
    public class MemberService:BaseService<Member>, IMemberService
    {
        public MemberService() : base(RepositoryFactory.MemberRepository)
        {
        }
        /// <summary>
        /// 创建身份验证
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <param name="authenticationType">默认验证类型</param>
        /// <returns>身份信息</returns>
        public ClaimsIdentity CreateIdentity(Member user, string authenticationType= DefaultAuthenticationTypes.ApplicationCookie)
        {
            ClaimsIdentity identity = new ClaimsIdentity(authenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.User_name));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.User_id.ToString()));
            identity.AddClaim(new Claim("Password", user.Password));
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            identity.AddClaim(new Claim("DisplayName", user.nickname));
            return identity;
            

        }
        /// <summary>
        /// 根据邮箱或手机号获得实体
        /// </summary>
        /// <param name="userName">手机号或邮箱</param>
        /// <returns></returns>
        public Member Find(string userName)
        {
            if (RegexUtil.IsMobilePhone(userName))
            {
                return CurrentRepository.Find(member => member.Phone_mob == userName);
            }
            return CurrentRepository.Find(member => member.Email == userName);
        }

        /// <summary>
        /// 根据指定字段的值是否存在
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">值</param>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            Member member = new Member();
            Type type = member.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            List<string> propertys = propertyInfos.Select(p => p.Name).ToList();
            if (propertys.Contains(field))
            {
                if (field.ToLower() == "email")
                {
                    return CurrentRepository.Exist(m => m.Email == value);
                }
                else
                {
                    return CurrentRepository.Exist(m => m.Phone_mob == value);
                }
                
                
            }
            return false;


        }

        /// <summary>
        /// 根据id获得实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Member Find(int id)
        {
            return CurrentRepository.Find(m => m.User_id == id);
        }
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <param name="id">userid</param>
        /// <param name="pwd">加密后的密码</param>
        /// <returns></returns>
        public Member Find(int id, string pwd)
        {
            return CurrentRepository.Find(m => m.User_id == id && m.Password == pwd);
        }
    }
}
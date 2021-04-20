using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{

    /// <summary>
    /// 用户表业务
    /// </summary>
    public class MemberService : BaseService<Member>, IMemberService
    {
        public MemberService(CosDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public async Task<MemberDto> FindAsync(int id)
        {
            var member = await this.MemberRepository.FindAsync(p => p.Id == id);
            if (member == null)
            {
                return null;
            }
            MemberDto dto = new MemberDto()
            {
                Id = member.Id,
                Portrait = member.Portrait,
                RongToken = member.RongToken,
                Nickname = member.Nickname,
                RealName = member.Real_name,
                Deposit = Math.Round(member.Deposit.ToDouble()).ToInt32(),
                ShenJia = member.Shenjia.GetValueOrDefault(),
                Surplus = member.RemainingConversions.GetValueOrDefault(),
                IsVip = member.Etime.GetValueOrDefault() >= DateTime.Now,
                Gender = member.Gender == "1" ? "男" : "女",
                Describe = member.Describe,
                PhoneMob = member.Phone_mob ?? "",
                ImAlipay = member.ImAlipay ?? ""
            };
            if (dto.IsVip)
            {
                dto.EndTime = member.Etime.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                dto.EndTime = "已过期或未充值";
            }
            dto.DepositState = await this.RefundRepository.FindList(r => r.UserId == id && r.Status == 0).AnyAsync();

            return dto;
        }
        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="portrait">头像地址</param>
        /// <returns>是否更新成功</returns>
        public async Task<bool> UpdatePortraitAsync(int id, string portrait)
        {
            Member member = await this.MemberRepository.FindAsync(p => p.Id == id);
            member.Portrait = portrait;
            return await this.MemberRepository.UpdateAsync(member);
        }

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
        public async Task<int> AddAsync(string type, string userName,string lastIp, string pwd = "", string nickname = "", string gender = "", string figureurl = "/Upload/Portrait/1.jpg")
        {
            if (gender == "男")
            {
                gender = "1";
            }
            if (gender == "女")
            {
                gender = "0";
            }
            Member member = new Member()
            {
                User_name = "",
                Email = "",
                Password = "",
                Real_name = "",
                Gender = gender,
                Birthday = "",
                Phone_tel = "",
                Phone_mob = "",
                Im_qq = "",
                Im_msn = "",
                In_skype = "",
                Im_yahoo = "",
                Im_aliww = "",
                Reg_time = DateTime.Now,
                Last_login = DateTime.Now,
                Last_ip = lastIp,
                Logins = 0,
                Ugrade = 0,
                Portrait = figureurl,
                Outer_id = "",
                Activation = "",
                Feed_config = "",
                Status = 1,
                Reward = 0,
                CNbi = 0,
                Integral = 0,
                Nickname = nickname,
                Ardent = 0,
                Growth = 0,
                Code = "",
                Describe = "",
                Shenjia = 0,
                Bean = "",
                Lv = 0,
                Conversions = 0,
                RemainingConversions = 0,
                Deposit = 0
            };
            switch (type)
            {
                case "QQ":
                    member.Im_qq = userName;
                    break;
                case "phone":
                    member.Phone_mob = userName;
                    member.Password = System.DEncryptHelper.Encrypt3DES(pwd);
                    break;
                case "wechat":
                    member.ImWechat = userName;
                    break;
                case "sina":
                    member.ImSina = userName;
                    break;
                default:
                    member.Phone_mob = userName;
                    member.Password = System.DEncryptHelper.Encrypt3DES(pwd);
                    break;
            }
            member = await this.MemberRepository.AddAsync(member);

            //member.RongToken = //RongCloudHelper.GetToken(member.Id.ToString());
            //bool b = this.MemberRepository.Update(member);
            //IpInfoModel ip = SysHelper.GetIpInfo(lastIp);
            //MemberRegister mr = new MemberRegister()
            //{
            //    AddTime = DateTime.Now,
            //    Area = ip.Area,
            //    City = ip.City,
            //    Country = ip.Country,
            //    County = ip.County,
            //    Ip = lastIp,
            //    Isp = ip.Isp,
            //    Region = ip.Region,
            //    Status = 1,
            //    UserId = member.Id
            //};
            //this.MemberRegisterRepository.Add(mr);
            return member.Id;
        }
        /// <summary>
        /// 是否已经存在用户
        /// </summary>
        /// <param name="type">注册类型，phone、QQ、wechat</param>
        /// <param name="userName">用户名，手机注册时为手机号，QQ注册时为openid</param>
        /// <returns>返回用户id</returns>
        public async Task<int> ExistAsync(string type, string userName)
        {
            Member member = null;
            switch (type)
            {
                case "QQ":
                    member = await this.MemberRepository.FindAsync(p => p.Im_qq == userName);
                    break;
                case "phone":
                    member = await this.MemberRepository.FindAsync(p => p.Phone_mob == userName);
                    break;
                case "wechat":
                    member = await this.MemberRepository.FindAsync(p => p.ImWechat == userName);
                    break;
                case "Email":
                    member = await this.MemberRepository.FindAsync(p => p.Email == userName);
                    break;
                case "sina":
                    member = await this.MemberRepository.FindAsync(p => p.ImSina == userName);
                    break;
                case "alipay":
                    member = await this.MemberRepository.FindAsync(p => p.ImAlipay == userName);
                    break;
                default:
                    member = await this.MemberRepository.FindAsync(p => p.Phone_mob == userName);
                    break;
            }
            return member?.Id ?? 0;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns>修改成功返回true</returns>
        public async Task<bool> UpdatePasswordAsync(string phone, string pwd)
        {
            var model = await this.MemberRepository.FindAsync(m => m.Phone_mob == phone);
            model.Password = System.DEncryptHelper.Encrypt3DES(pwd);
            return await this.MemberRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 获得用户id
        /// </summary>
        /// <param name="type">注册类型，phone、QQ、wechat、Email</param>
        /// <param name="userName">用户名，手机注册时为手机号，QQ注册时为openid</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户id</returns>
        public async Task<int> FindAsync(string type, string userName, string pwd)
        {
            Member member = null;
            switch (type)
            {
                case "QQ":
                    member = await this.MemberRepository.FindAsync(p => p.Im_qq == userName);
                    break;
                case "phone":
                    member = await this.MemberRepository.FindAsync(p => p.Phone_mob == userName && p.Password == System.DEncryptHelper.Encrypt3DES(pwd));
                    break;
                case "wechat":
                    member = await this.MemberRepository.FindAsync(p => p.ImWechat == userName);
                    break;
                case "Email":
                    member = await this.MemberRepository.FindAsync(p => p.Email == userName && p.Password == System.DEncryptHelper.Encrypt3DES(pwd));
                    break;
                default:
                    member = await this.MemberRepository.FindAsync(p => p.Phone_mob == userName);
                    break;
            }
            return member?.Id ?? 0;
        }
        /// <summary>
        /// 获得应交押金
        /// </summary>
        /// <returns></returns>
        public  async Task<int> GetDepositAsync(int id, int value)
        {
            var depositControl = await this.DepositControlRepository.FindAsync(d => d.StartValue <= value && d.EndValue > value); //总押金
            var member = await this.MemberRepository.FindAsync(m => m.Id == id);  //已交押金
            if ((depositControl?.RefValue ?? 100) <= (member.Deposit ?? 0))
            {
                return 0;
            }
            else
            {
                return Math.Round((depositControl?.RefValue ?? 100) - (member.Deposit ?? 0)).ToInt32();
            }

        }
        /// <summary>
        /// 更新融云token
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="rongToken">新的token</param>
        /// <returns></returns>
        public async Task<bool> UpdateRongTokenAsync(int userId, string rongToken)
        {
            var model = await this.MemberRepository.FindAsync(m => m.Id == userId);
            model.RongToken = rongToken;
            return await this.MemberRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 更新个性信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(MemberDto dto)
        {
            var model = await this.MemberRepository.FindAsync(m => m.Id == dto.Id);
            if (!string.IsNullOrWhiteSpace(dto.Describe))
            {
                model.Describe = dto.Describe;
            }
            if (!string.IsNullOrWhiteSpace(dto.Nickname))
            {
                model.Nickname = dto.Nickname;
            }
            if (!string.IsNullOrWhiteSpace(dto.Gender))
            {
                model.Gender = dto.Gender;
            }
            if (!string.IsNullOrWhiteSpace(dto.PhoneMob))
            {
                model.Phone_mob = dto.PhoneMob;
            }
            if (!string.IsNullOrWhiteSpace(dto.ImAlipay))
            {
                model.ImAlipay = dto.ImAlipay;
            }
            if (!string.IsNullOrWhiteSpace(dto.RealName))
            {
                model.Real_name = dto.RealName;
            }

            return await this.MemberRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 获得用户数
        /// </summary>
        /// <returns></returns>
        public int GetUserCount(DateTime? dateTime =null)
        {
            if (dateTime == null)
            {
                return this.MemberRepository.Count(m => m.Status > 0);
            }
            return this.MemberRepository.Count(m => m.Status>0 && m.Reg_time.GetValueOrDefault().Date == dateTime.GetValueOrDefault().Date);
        }
        /// <summary>
        /// 获得会员数
        /// </summary>
        /// <returns></returns>
        public int GetUserVipCount(DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                return this.MemberRepository.Count(m => m.Lv > 0);
            }
            return this.MemberRepository.Count(m => m.Lv > 0 && (dateTime != null && m.Reg_time.GetValueOrDefault().Date == dateTime.GetValueOrDefault().Date));
        }
    }
}
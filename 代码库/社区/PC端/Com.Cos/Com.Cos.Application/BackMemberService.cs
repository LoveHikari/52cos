using System;
using System.Collections.Generic;
using System.Linq;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    public class BackMemberService : BaseService<Member>, IBackMemberService
    {
        public BackMemberService(CosDbContext dbContext) : base(dbContext)
        {
        }

        public List<MemberDto> FindList()
        {
            var v = from m in this.DbContext.Members
                    join sp in this.DbContext.SysParas on new { Gender = m.Gender, RefType = "sex" } equals new { Gender = sp.RefValue, RefType = sp.RefType } into spi
                    from sp in spi.DefaultIfEmpty()
                    join mr in this.DbContext.MemberRegisters on m.Id equals mr.UserId into mri
                    from mr in mri.DefaultIfEmpty()
                    select new MemberDto()
                    {
                        Id = m.Id,
                        Nickname = m.Nickname,
                        Gender = sp.RefText,
                        PhoneMob = m.Phone_mob,
                        IsVip = m.Etime.GetValueOrDefault() >= DateTime.Now,
                        AddTime = m.Reg_time.GetValueOrDefault(),
                        Address = mr.Country + mr.Area + mr.Region + mr.City
                    };


            return v.ToList();
        }
    }
}
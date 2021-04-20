using System.Collections.Generic;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    public interface IBackMemberService : IBaseService<Member>
    {
        List<MemberDto> FindList();
    }
}
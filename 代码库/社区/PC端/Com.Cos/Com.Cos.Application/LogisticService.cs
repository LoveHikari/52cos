using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Application
{
    /// <summary>
    /// 物流信息表业务
    /// </summary>
    public class LogisticService : BaseService<Logistic>, ILogisticService
    {
        public LogisticService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 添加物流信息
        /// </summary>
        /// <param name="dto"></param>
        public async Task AddAsync(LogisticDto dto)
        {
            bool b = await this.LogisticRepository.ExistAsync(l => l.LogisticCode == dto.LogisticCode &&
                                               l.AcceptStation == dto.AcceptStation && l.State == dto.State);
            if (!b)
            {
                var model = new Logistic()
                {
                    AcceptStation = dto.AcceptStation,
                    AcceptTime = dto.AcceptTime,
                    AddTime = DateTime.Now,
                    EstimatedDeliveryTime = dto.EstimatedDeliveryTime,
                    LogisticCode = dto.LogisticCode,
                    PickerInfo = dto.PickerInfo,
                    Remark = dto.Remark,
                    SenderInfo = dto.SenderInfo,
                    ShipperCode = dto.ShipperCode,
                    State = dto.State,
                    Status = 1
                };
                model = await this.LogisticRepository.AddAsync(model);
            }

        }
        /// <summary>
        /// 获得物流信息列表
        /// </summary>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        public List<LogisticDto> FindList(string logisticCode)
        {
            /*SELECT sc.Company,l.LogisticCode,s.RefText,l.AcceptTime,l.AcceptStation FROM dbo.sns_logistic l
            LEFT JOIN dbo.cos_sysPara s ON s.RefValue=l.State AND s.RefType='logisticState'
            LEFT JOIN dbo.sns_shipperCompany sc ON sc.Code=l.ShipperCode 
            ORDER BY l.AcceptTime DESC*/
            var v = from l in this.DbContext.Logistics
                    join s in this.DbContext.SysParas on new { state = l.State, type = "logisticState" } equals new { state = s.RefValue.ToInt32(0), type = s.RefType } into si
                    from s in si.DefaultIfEmpty()
                    join sc in this.DbContext.ShipperCompanies on l.ShipperCode equals sc.Code into sci
                    from sc in sci.DefaultIfEmpty()
                    where l.LogisticCode == logisticCode
                    orderby l.AcceptTime descending 
                    select new LogisticDto
                    {
                        Id = l.Id,
                        Company = sc.Company,
                        LogisticCode = l.LogisticCode,
                        StateText = s.RefText,
                        AcceptTime = l.AcceptTime,
                        AcceptStation = l.AcceptStation,
                    };
            var list = v.ToList();

            return list;
        }
    }
}
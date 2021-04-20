using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Com.Cos.BLL;
using Com.Cos.IBLL;
using Com.Cos.Models;
using Com.Cos.Web.Models;

namespace Com.Cos.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IMailingAddressService _mailingAddressService;

        public AddressController()
        {
            _mailingAddressService = new MailingAddressService();
        }

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }
        // POST: Address/Add
        [System.Web.Mvc.HttpPost,System.Web.Mvc.AllowAnonymous]
        public ActionResult Add(AddressViewModel model)
        {
            MessageBase result = new MessageBase();
            if (model.UserId > 0)
            {
                var v = new MailingAddress()
                {
                    UserId = model.UserId.ToString(),
                    Province = model.Province,
                    City = model.City,
                    County = model.County,
                    Address = model.Address,
                    Name = model.Name,
                    Phone = model.Phone,
                    ZipCode = model.ZipCode,
                    AddTime = DateTime.Now,
                    Status = 1
                };

                _mailingAddressService.Add(v);
                result.Status = Constant.SUCCESS;
            }
            else
                result.Status = Constant.FAILED;
            
            return Json(result);
        }
    }
}
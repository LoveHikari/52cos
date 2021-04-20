using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Com.Cos.Application;
using Com.Cos.Application.Interfaces;

namespace Com.Cos.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMemberService _memberService;
        public ValuesController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {



            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet,Route("Error")]
        public void Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            LogHelper.WriteError(error);
        }
    }
}

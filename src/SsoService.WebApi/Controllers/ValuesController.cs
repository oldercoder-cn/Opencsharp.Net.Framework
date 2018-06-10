using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Data.DbFactory;
using Microsoft.AspNetCore.Mvc;

namespace SsoService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        
       
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Data.DbFactory.IDatabase database  = BaseUtility.Ioc.AutofacHelper.GetDbInstance<Data.DbFactory.IDatabase>("Data.Orm.EF.SqlServerDatabase",
                new ResolvedParameter(
           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "conn",
           (pi, ctx) => "Data Source = .;Initial Catalog = Opencsharp.Net;Integrated Security = SSPI;")
                );
            Data.DbFactory.IDatabase database2 = BaseUtility.Ioc.AutofacHelper.GetDbInstance<Data.DbFactory.IDatabase>("Data.Orm.EF.SqlServerDatabase");
            database.Select("d");
            database2.Select("d");

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
    }
}

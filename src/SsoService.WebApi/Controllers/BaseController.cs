using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DbFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SsoService.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {
        static readonly string dbInstance = "";
        static readonly string connStr = "";
        protected static Repository baseDb = new Repository(dbInstance);//默认数据库
        protected static Repository childDb = new Repository(dbInstance,connStr);//指定链接的数据库
    }
}
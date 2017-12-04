using Chainway.OpenCityPlatform.BLL;
using Chainway.OpenCityPlatform.Entity;
using SOAFramework.Library;
using SOAFramework.Service.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Chainway.OpenCityPlatform.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Common.RollbackTransaction();
            SimpleLogger logger = new SimpleLogger();
            logger.WriteException(context.Exception);
            Session.RemoveCurrent();

            CommonResponse response = new CommonResponse();
            response.Exception = context.Exception;
            response.IsError = true;
            Session.RemoveCurrent();
        }
    }
}

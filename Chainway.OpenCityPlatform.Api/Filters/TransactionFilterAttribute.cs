using Chainway.OpenCityPlatform.BLL;
using IBatisNet.DataMapper;
using SOAFramework.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Chainway.OpenCityPlatform.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TransactionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var mapper = Common.StoreMapper();
            Session.Current[Common.mapperKey] = mapper;
            mapper.BeginTransaction();
            Session.Current[Common.transKey] = true;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null) Common.CommitTransaction();
            Session.RemoveCurrent();
        }
    }
}

using Chainway.OpenCityPlatform.BLL;
using IBatisNet.DataMapper;
using SOAFramework.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Chainway.OpenCityPlatform.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorityFilterAttribute: AuthorizationFilterAttribute
    {
    }
}

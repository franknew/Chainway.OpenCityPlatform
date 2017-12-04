using System;
using System.Collections.Generic;
using System.Text;

namespace Chainway.OpenCityPlatform.BLL
{
    public class ChainwayException: Exception
    {
        public ChainwayException()
        { }

        public ChainwayException(int code, string message): base(message)
        {
            this.Code = code;
        }

        public int Code { get; set; }
    }
}

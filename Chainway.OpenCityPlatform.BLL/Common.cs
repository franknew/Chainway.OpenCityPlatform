using IBatisNet.DataMapper;
using SOAFramework.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainway.OpenCityPlatform.BLL
{
    public class Common
    {
        public static readonly string mapperKey = "__mapper";
        public static readonly string meKey = "__me";
        public static readonly string transKey = "__beginTrans";

        public static ISqlMapper StoreMapper()
        {
            var mapper = Mapper.Instance();
            Session.Current[mapperKey] = mapper;
            return mapper;
        }

        public static ISqlMapper GetMapper()
        {
            return Session.Current[mapperKey] as ISqlMapper;
        }

        public static void BeginTransaction()
        {
            var mapper = GetMapper();
            mapper.BeginTransaction();
            Session.Current[transKey] = true;
        }

        public static void CommitTransaction()
        {
            var mapper = GetMapper();
            bool beginTrans = false;
            var beginTransTemp = Session.Current[transKey];
            beginTrans = (bool)beginTransTemp;
            if (beginTrans) mapper.CommitTransaction();
        }

        public static void RollbackTransaction()
        {
            var mapper = GetMapper();
            bool beginTrans = false;
            var beginTransTemp = Session.Current[transKey];
            beginTrans = (bool)beginTransTemp;
            if (beginTrans) mapper.RollBackTransaction();
        }
    }
}

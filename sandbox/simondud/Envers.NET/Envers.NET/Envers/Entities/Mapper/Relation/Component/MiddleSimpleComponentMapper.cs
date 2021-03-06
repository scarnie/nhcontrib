﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Envers.Configuration;
using NHibernate.Envers.Entities.Mapper.Id;
using NHibernate.Envers.Tools.Query;

namespace NHibernate.Envers.Entities.Mapper.Relation.Component
{
    class MiddleSimpleComponentMapper: IMiddleComponentMapper
    {
        private readonly AuditEntitiesConfiguration verEntCfg;
        private readonly String propertyName;

        public MiddleSimpleComponentMapper(AuditEntitiesConfiguration verEntCfg, String propertyName)
        {
            this.propertyName = propertyName;
            this.verEntCfg = verEntCfg;
        }

        public object MapToObjectFromFullMap(EntityInstantiator entityInstantiator, IDictionary<string, object> data, object dataObject, long revision)
        {
            return ((IDictionary<String, Object>)data[verEntCfg.OriginalIdPropName])[propertyName];
        }

        public void MapToMapFromObject(IDictionary<string, object> data, object obj)
        {
            data.Add(propertyName, obj);
        }

        public void AddMiddleEqualToQuery(Parameters parameters, string prefix1, string prefix2)
        {
            parameters.AddWhere(prefix1 + "." + propertyName, false, "=", prefix2 + "." + propertyName, false);
        }
    }
}

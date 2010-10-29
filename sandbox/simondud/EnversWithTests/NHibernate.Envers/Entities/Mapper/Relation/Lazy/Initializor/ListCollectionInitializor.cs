using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Envers.Configuration;
using NHibernate.Envers.Entities.Mapper.Relation.Query;
using NHibernate.Envers.Reader;

namespace NHibernate.Envers.Entities.Mapper.Relation.Lazy.Initializor
{
	public class ListCollectionInitializor<T> : AbstractCollectionInitializor<IList<T>>
	{
		private readonly MiddleComponentData _elementComponentData;
		private readonly MiddleComponentData _indexComponentData;

		public ListCollectionInitializor(AuditConfiguration verCfg, 
											IAuditReaderImplementor versionsReader, 
											IRelationQueryGenerator queryGenerator, 
											object primaryKey, 
											long revision,
											MiddleComponentData elementComponentData,
											MiddleComponentData indexComponentData) 
								: base(verCfg, versionsReader, queryGenerator, primaryKey, revision)
		{
			_elementComponentData = elementComponentData;
			_indexComponentData = indexComponentData;
		}

		protected override IList<T> InitializeCollection(int size)
		{
			var ret = new List<T>(size);
			for (var i = 0; i < size; i++)
			{
				ret.Add(default(T));
			}
			return ret;
		}

		protected override void AddToCollection(IList<T> collection, object collectionRow)
		{
			var elementData = ((IList)collectionRow)[_elementComponentData.ComponentIndex];
			var element = (T)_elementComponentData.ComponentMapper.MapToObjectFromFullMap(entityInstantiator,
																				(IDictionary<String, Object>)elementData, 
																				null, 
																				revision);

			var indexData = ((IList)collectionRow)[_indexComponentData.ComponentIndex];
			var index = (int)_indexComponentData.ComponentMapper.MapToObjectFromFullMap(entityInstantiator,
																				(IDictionary<String, Object>)indexData, 
																				element, 
																				revision);
			collection[index] = element;
		}
	}
}
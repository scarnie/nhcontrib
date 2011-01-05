﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernate.Envers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Field)]
    public class JoinColumnAttribute : Attribute
    {
	    /**
	     * The name of the foreign key column.
	     * The table in which it is found depends upon the context. If the join is for a OneToOne
	     * or Many- ToOne mapping, the foreign key column is in the table of the source entity.
	     * If the join is for a ManyToMany, the foreign key is in a join table. Default (only applies
	     * if a single join column is used): The concatenation of the following: the name of the referencing
	     * relationship property or field of the referencing entity; "_"; the name of the referenced primary
	     * key column. If there is no such referencing relationship property or field in the entity, the join
	     * column name is formed as the concatenation of the following: the name of the entity; "_"; the name
	     * of the referenced primary key column.
	     */
	    String name = "";
	    /**
	     * The name of the column referenced by this foreign key column. When used with relationship mappings,
	     * the referenced column is in the table of the target entity. When used inside a JoinTable annotation,
	     * the referenced key column is in the entity table of the owning entity, or inverse entity if the join
	     * is part of the inverse join definition. Default (only applies if single join column is being used):
	     * The same name as the primary key column of the referenced table.
	     */
	    String referencedColumnName = "";
	    /**
	     * Whether the property is a unique key. This is a shortcut for the UniqueConstraint annotation at the
	     * table level and is useful for when the unique key constraint is only a single field. It is not
	     * necessary to explicitly specify this for a join column that corresponds to a primary key that is part
	     * of a foreign key.
	     */
	    bool unique = false;
	    /**
	     * Whether the foreign key column is nullable
	     */
	    bool nullable = true;
	    /**
	     * Whether the column is included in SQL INSERT statements generated by the persistence provider
	     */
	    bool insertable = true;
	    /**
	     * Whether the column is included in SQL UPDATE statements generated by the persistence provider
	     */
	    bool updatable = true;
	    /**
	     * The SQL fragment that is used when generating the DDL for the column.
	     * Defaults to the generated SQL for the column.
	     */
	    String columnDefinition = "";
	    /**
	     * The name of the table that contains the column. If a table is not specified, the column is
	     * assumed to be in the primary table of the applicable entity
	     */
	    String table = "";

    }
}

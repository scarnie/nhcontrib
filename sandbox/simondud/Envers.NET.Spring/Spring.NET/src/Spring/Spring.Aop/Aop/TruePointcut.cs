#region License

/*
 * Copyright � 2002-2005 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

#region Imports

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

#endregion

namespace Spring.Aop
{
	/// <summary>
	/// Canonical <see cref="Spring.Aop.IPointcut"/> instance that matches
	/// everything.
	/// </summary>
	/// <author>Rod Johnson</author>
	/// <author>Aleksandar Seovic (.NET)</author>
	[Serializable]
	public sealed class TruePointcut : IPointcut, ISerializable
	{
		/// <summary>
		/// Canonical instance that matches everything.
		/// </summary>
		public static readonly IPointcut True = new TruePointcut();

		/// <summary>
		/// Creates a new instance of the
		/// <see cref="TruePointcut"/> class.
		/// </summary>
		/// <remarks>
		/// <p>
		/// This is a utility class, and as such has no publicly
		/// visible constructors.
		/// </p>
		/// </remarks>
		private TruePointcut()
		{
		}

		/// <summary>
		/// The <see cref="Spring.Aop.ITypeFilter"/> for this pointcut.
		/// </summary>
		/// <value>
		/// The current <see cref="Spring.Aop.ITypeFilter"/>.
		/// </value>
		public ITypeFilter TypeFilter
		{
			get { return Aop.TrueTypeFilter.True; }
		}

		/// <summary>
		/// The <see cref="Spring.Aop.IMethodMatcher"/> for this pointcut.
		/// </summary>
		/// <value>
		/// The current <see cref="Spring.Aop.IMethodMatcher"/>.
		/// </value>
		public IMethodMatcher MethodMatcher
		{
			get { return TrueMethodMatcher.True; }
		}

		/// <summary>
		/// A <see cref="System.String"/> that represents the current
		/// <see cref="Spring.Aop.IPointcut"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current
		/// <see cref="Spring.Aop.IPointcut"/>.
		/// </returns>
		public override string ToString()
		{
			return "TruePointcut.TRUE";
		}

		/// <summary>
		/// Populates a <see cref="System.Runtime.Serialization.SerializationInfo"/> with
		/// the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">
		/// The <see cref="System.Runtime.Serialization.SerializationInfo"/> to populate
		/// with data.
		/// </param>
		/// <param name="context">
		/// The destination (see <see cref="System.Runtime.Serialization.StreamingContext"/>)
		/// for this serialization.
		/// </param>
		[SecurityPermission (SecurityAction.Demand,SerializationFormatter=true)]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.SetType(typeof (TruePointcutObjectReference));
		}

		[Serializable]
		private sealed class TruePointcutObjectReference : IObjectReference
		{
			public object GetRealObject(StreamingContext context)
			{
				return TruePointcut.True;
			}
		}
	}
}

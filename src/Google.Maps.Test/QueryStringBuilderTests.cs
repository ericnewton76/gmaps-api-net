using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;

namespace Google.Maps.Test
{
	[TestFixture]
	public class QueryStringBuilderTests
	{

		public class QueryStringBuilderAccessor
		{
			private static Type S_instanceType;
			private static MethodInfo S_Append;

			private object _instance;

			static QueryStringBuilderAccessor()
			{
				S_instanceType = Type.GetType("Google.Maps.QueryStringBuilder");

			}
			public QueryStringBuilderAccessor()
			{
				_instance = Activator.CreateInstance(S_instanceType);
			}

			public QueryStringBuilderAccessor Append(string value)
			{
				
				return this;
			}
		}

	}
}

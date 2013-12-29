//
// Portability Class Library
//
// Copyright © Cureos AB, 2013
// info at cureos dot com
//

using System;
using System.Linq;
using System.Reflection;

namespace Accord
{
	public static class TypeExtensions
	{
		public static ConstructorInfo GetConstructor(this Type thisType, Type[] types)
		{
			var typeInfo = thisType.GetTypeInfo();
			foreach (var constructorInfo in typeInfo.DeclaredConstructors)
			{
				var constructorTypes = constructorInfo.GetParameters().Select(param => param.ParameterType).ToArray();
				if (constructorTypes.Length != types.Length) continue;
				var use = true;
				for (var i = 0; i < constructorTypes.Length; ++i)
				{
					if (constructorTypes[i] != types[i])
					{
						use = false;
						break;
					}
				}
				if (use) return constructorInfo;
			}
			return null;
		}
	}
}
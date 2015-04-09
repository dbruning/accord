// Accord.Core Library
// The Portable Accord.NET Framework
// https://github.com/cureos/accord
//
// Copyright © Anders Gustafsson, 2013-2014
// anders at cureos dot com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal static class TypeExtensions
    {
        internal static ConstructorInfo GetConstructor(this Type thisType, Type[] types)
        {
            var typeInfo = thisType.GetTypeInfo();
            foreach (var constructorInfo in typeInfo.DeclaredConstructors)
            {
                var constructorTypes = constructorInfo.GetParameters().Select(param => param.ParameterType).ToArray();
                if (constructorTypes.Length != types.Length)
                {
                    continue;
                }
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

        internal static FieldInfo GetField(this Type thisType, string name)
        {
            return thisType.GetRuntimeField(name);
        }
    }
}
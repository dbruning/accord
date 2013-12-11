//
// Portability Class Library
//
// Copyright © Cureos AB, 2013
// info at cureos dot com
//

namespace System.Runtime.InteropServices
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    public class ComVisibleAttribute : Attribute
    {
         public ComVisibleAttribute(bool visibility) { }
    }
}
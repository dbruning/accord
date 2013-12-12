//
// Portability Class Library
//
// Copyright © Cureos AB, 2013
// info at cureos dot com
//

namespace System.Diagnostics
{
    public static class Trace
    {
        public static void WriteLine(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }

        public static void TraceWarning(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
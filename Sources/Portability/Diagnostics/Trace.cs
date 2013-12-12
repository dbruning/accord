namespace System.Diagnostics
{
    public static class Trace
    {
        public static void WriteLine(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }
    }
}
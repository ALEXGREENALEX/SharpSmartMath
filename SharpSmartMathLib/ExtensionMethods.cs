using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSmartMathLib;

namespace ExtMethods
{
    public static class ExtensionMethods
    {
        public static void Dump(this Object obj)
        {
            if (obj == null)
                DynamicCompile.VirtualConsoleOutput.Add("'null'");
            else if (obj.GetType() == typeof(string))
                DynamicCompile.VirtualConsoleOutput.Add("\"" + obj.ToString() + "\"");
            else
                DynamicCompile.VirtualConsoleOutput.Add(obj.ToString());
        }

        public static void LogError(this Object obj)
        {
            if (obj == null)
                DynamicCompile.VirtualConsoleErrorsOutput.Add("'null'");
            else if (obj.GetType() == typeof(string))
                DynamicCompile.VirtualConsoleErrorsOutput.Add("\"" + obj.ToString() + "\"");
            else
                DynamicCompile.VirtualConsoleErrorsOutput.Add(obj.ToString());
        }

        public static int length(this Array arr)
        {
            return arr.Length;
        }
    }
}

namespace LibExtMethods
{
    public static class ExtensionMethods
    {
        public static int CountStringOccurrences(this string text, string pattern)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
}
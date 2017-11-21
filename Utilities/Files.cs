using System;
using System.IO;
using System.Reflection;

namespace Utilities
{
    public static class Files
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string ProjectDirectory
        {
            get
            {
                return Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\.."));
            }
        }
    }
}

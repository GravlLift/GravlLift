using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace FantasyFootball.Data
{
    public static class CsvObjectLoader
    {
        public static List<T> LoadObjects<T>(string relativeCsvPath)
        {
            if (relativeCsvPath[0] != '\\')
                relativeCsvPath = "\\" + relativeCsvPath;
            relativeCsvPath = @"..\.." + relativeCsvPath;

            Type type = typeof(T);
            List<T> objects = new List<T>();
            using (var reader = new StreamReader(Path.Combine(Utilities.Files.AssemblyDirectory, relativeCsvPath)))
            {
                string[] propertyNames = reader.ReadLine().Split(',');

                PropertyInfo[] objectProperties = type.GetProperties();

                for (int i = 0; i < propertyNames.Length; i++)
                {
                    if (!objectProperties.Any(p => p.Name == propertyNames[i]))
                        propertyNames[i] = null;
                }

                while (!reader.EndOfStream)
                {
                    dynamic obj = FormatterServices.GetUninitializedObject(type);
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    for (int i = 0; i < propertyNames.Length; i++)
                    {
                        if (propertyNames[i] == null || values[i] == "NULL")
                            continue;

                        PropertyInfo propertyInfo = type.GetProperty(propertyNames[i]);
                        propertyInfo.SetValue(obj, Convert.ChangeType(values[i], Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType));
                    }
                    objects.Add(obj);
                }
            }
            return objects;
        }
    }
}

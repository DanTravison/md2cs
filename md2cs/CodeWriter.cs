﻿using System;
using System.Collections.Generic;
using md2cs.Helpers;

namespace md2cs
{
    public class CodeWriter
    {
        public string Write(IEnumerable<MaterialDesignIcon> icons)
        {
            Console.Write("Generating C# code...");

            var classTemplate = ResourcesHelper.ReadResourceContent("ClassTemplate.txt");
            var propertyTemplate = ResourcesHelper.ReadResourceContent("PropertyTemplate.txt");

            var properties = new List<string>();

            foreach (var icon in icons)
            {
                var property = propertyTemplate.Replace("$link$", icon.Url)
                                               .Replace("$name$", icon.Name)
                                               .Replace("$code$", icon.Unicode)
                                               .Replace("$dotnet_name$", icon.DotNetName);

                properties.Add(property);
            }

            var separator = Environment.NewLine + Environment.NewLine;
            var code = string.Join(separator, properties);

            return classTemplate.Replace("$properties$", code);
        }
    }
}

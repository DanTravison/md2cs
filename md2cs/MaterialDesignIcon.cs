using System;
using System.Collections.Generic;
using System.Diagnostics;
using md2cs.Helpers;

namespace md2cs
{
    [DebuggerDisplay("{Name} - {DotNetName}")]
    public class MaterialDesignIcon
    {
        class MaterialDesignIconComparer : IComparer<MaterialDesignIcon>
        {
            public int Compare(MaterialDesignIcon x, MaterialDesignIcon y)
            {
                return StringComparer.OrdinalIgnoreCase.Compare(x.DotNetName, y.DotNetName);
            }
        }

        /// <summary>
        /// Gets an <see cref="IComparer{MatericalDesignIcon"/>.
        /// </summary>
        public static readonly IComparer<MaterialDesignIcon> DotNetNameComparer = new MaterialDesignIconComparer();

        public MaterialDesignIcon(string name, string codepoint, string url)
        {
            Name = name;
            DotNetName = DotNetNameHelper.ToDotNetName(Name);
            Unicode = codepoint;
            Url = url;
        }

        public string Name { get; }
        public string Unicode { get; }
        public string Url { get; }
        public string DotNetName { get; }
    }
}

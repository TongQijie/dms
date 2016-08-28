using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Petecat.Extension;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Dev.Brother
{
    [Resolvable]
    public class CacheData : ICacheData
    {
        public CacheData(string cachePath)
        {
            CachePath = cachePath;

            if (!File.Exists(cachePath.FullPath()))
            {
                File.Create(cachePath.FullPath()).Close();
            }

            using (var streamReader = new StreamReader(cachePath.FullPath(), Encoding.UTF8))
            {
                string line = null;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Values.Add(line);
                }
            }
        }

        public string CachePath { get; private set; }

        private List<string> Values = new List<string>();

        public void Add(string value)
        {
            if (!Exists(value))
            {
                Values.Add(value);
            }
        }

        public bool Exists(string value)
        {
            return Values.Exists(x => x.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public void Flush()
        {
            using (var streamWriter = new StreamWriter(CachePath.FullPath(), false, Encoding.UTF8))
            {
                foreach (var value in Values)
                {
                    streamWriter.WriteLine(value);
                }
            }
        }
    }
}

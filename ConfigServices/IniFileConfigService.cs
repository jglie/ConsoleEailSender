using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConfigServices
{
    
    public class IniFileConfigService : IConfigService
    {
        public string FilePath { get; set; }
        public string GetValue(string name)
        {
           var kv =  File.ReadLines(FilePath, Encoding.UTF8).Select(s => s.Split('=')).Select(str => new { Name = str[0], Value = str[1] })
                .SingleOrDefault(x=>x.Name == name);
            if (kv != null)
            {
                return kv.Value;
            }
            else {
                return null;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace moxpass.Config
{
    public class ConfigHandler
    {
    }

    public class Settings
    {
        public string this[string key]
        {
            get
            {
                return d[key];
            }
            set
            {
                d[key] = value;
            }
        }

        private Dictionary<string, string> d = 
            new Dictionary<string, string>();
    }
}

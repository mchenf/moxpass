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
        private string settingFilePath;
        public static readonly string[] Options = new string[]
        {
            "User.Email=", "Secret.DisplayTime="
        };
        public Settings(string filePath)
        {

            this.settingFilePath = filePath;
            if(!File.Exists(settingFilePath))
            {
                string tx = string.Join(Environment.NewLine, Options);
                byte[] b = Encoding.UTF8.GetBytes(tx);
                using (var fs = File.Create(settingFilePath))
                {
                    fs.Write(b, 0, b.Length);
                }
            }
            string content = File.ReadAllText(settingFilePath);
            string[] lines = content.Split(Environment.NewLine);
            foreach (string line in lines)
            {
                string[] kvp = line.Split('=');

                switch (kvp.Length)
                {
                    case 1:
                        this[kvp[0]] = "";
                        break;
                    case 2:
                        this[kvp[0]] = kvp[1];
                        break;
                    default:
                        break;
                }

            }

        }
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

        public void Save()
        {
            StringBuilder sb = new StringBuilder();

            int len = d.Count();

            foreach (var kvp in d)
            {
                sb.Append(kvp.Key);
                sb.Append("=");
                sb.Append(kvp.Value);
                if(len > 0) sb.AppendLine();
                len--;
            }
            File.WriteAllText(settingFilePath, sb.ToString());
        }
    }
}

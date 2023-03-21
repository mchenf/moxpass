using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace moxpass_gui.Models
{
    public enum UILanguageOptions
    {
        enUS,
        zhCN
    }

    public class UILanguage
    {
        private Dictionary<UILanguageOptions, string> content;
        public string this[UILanguageOptions language] 
        { 
            get { return content[language];} 
            set { content[language] = value;}
        }

        public UILanguage()
        {
            content = new Dictionary<UILanguageOptions, string>();
        }
    }

    public class UiTextResource
    {
        private Dictionary<string, UILanguage> content;
        public UILanguage this[string key]
        {
            get { return content[key]; }
            set { content[key] = value; }
        }

        public UiTextResource()
        {
            content = new Dictionary<string, UILanguage>();
        }
    }
}

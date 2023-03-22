using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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
        public string this[string key, UILanguageOptions opt]
        {
            set 
            {

                UILanguage lang = null;
                if(!content.TryGetValue(key, out lang))
                {
                    lang = new UILanguage();
                }
                lang[opt] = value;
                content[key] = lang;
            }
        }

        public string this[string key]
        {
            get
            {
                return content[key][CurrentLangSetting];
            }
        }

        public UiTextResource()
        {
            content = new Dictionary<string, UILanguage>();
        }

        public UILanguageOptions CurrentLangSetting { get; set; } = UILanguageOptions.enUS;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using MultiLanguage;
using System.Windows.Forms;

namespace MultiLanguage
{
    public static class Language
    {
        public static void Update(string culture = "en-US")
        {
            if (AppSettings.AddUpdateAppSettings("language", culture))
            {
                if (MessageBox.Show(Resources.strings.msgUpdateRestart, Resources.strings.msgUpdateTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        public static string Get()
        {
            string result = AppSettings.ReadSetting("language");
            return (result == "Not Found") ? "en-US" : result;
        }
    }
}

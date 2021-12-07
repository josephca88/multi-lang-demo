using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLanguage
{
    public partial class Form1 : Form
    {
        private int _currLangIdx = 0;
        private bool _isLoading = false;

        private Dictionary<string, string> _langDict;

        public Form1()
        {
            InitializeComponent();

            _isLoading = true;
            label1.Text = Resources.strings.msgHello;
            label2.Text = Resources.strings.msgLong;

            _langDict = new Dictionary<string, string>();
            _langDict.Add("English", "en-US");
            _langDict.Add("French", "fr-FR");

            InitCombo();
            _isLoading = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
            {
                try
                {
                    if (MessageBox.Show(Resources.strings.msgUpdateLanguage, Resources.strings.msgUpdateTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ListBox ctl = (ListBox)sender;
                        _currLangIdx = ctl.SelectedIndex;
                        Language.Update(_langDict.Values.ToArray()[_currLangIdx]);
                    }
                }
                catch
                {

                }
            }
        }

        void InitCombo()
        {
            listBox1.Items.AddRange(_langDict.Keys.ToArray());

            string lang = Language.Get();
            listBox1.SelectedIndex = _langDict.Values.ToList().IndexOf(lang);
        }
    }
}

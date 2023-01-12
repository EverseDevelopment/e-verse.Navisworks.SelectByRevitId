using EVerse.Navisworks.Plugin.RevitId.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EVerse.Navisworks.Plugin
{
    /// <summary>
    /// Interaction logic for SelectByIdWindow.xaml
    /// </summary>
    public partial class SelectByIdWindow : Window
    {
        public SelectByIdWindow()
        {
            InitializeComponent();
        }
        //protected override bool ProcessDialogKey(KeyInter keyData)
        //{
        //    if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}
        private void okButton_Click(object sender, EventArgs e)
        {
            var s = Tools.splitString(textBox.Text);
            Tools.getElements(s);
            this.DialogResult = true;
        }
    }
}

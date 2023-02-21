using Autodesk.Navisworks.Api;
using EVerse.Navisworks.Plugin.Common;
using EVerse.Navisworks.SelectByRevitId.Plugin.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace EVerse.Navisworks.SelectByRevitId.Plugin
{
    /// <summary>
    /// Interaction logic for SelectByIdWindow.xaml
    /// </summary>
    public partial class SelectByIdWindow : Window
    {
        //private const string ADDIN_IMAGE_PATH = "Images\\RID_32.jpg";
        private const string HEART_IMAGE_PATH = "Images\\Heart.jpg";
        private const string NO_REVIT_MODEL_MESSAGE = "No revit model available";
        private const string INSERT_ELEMENT_ID_MESSAGE = "Insert element revit ID";

        public SelectByIdWindow()
        {
            InitializeComponent();
            InitializeValues();
        }
        private void InitializeValues()
        {
            if (!Tools.IsRevitModelLoaded())
                OffOn(false, NO_REVIT_MODEL_MESSAGE);
            else OffOn(true, INSERT_ELEMENT_ID_MESSAGE);

        }
        private void FinDisclaimerButtonChildImage(object sender, RoutedEventArgs e)
        {
            Button disclaimerButton = sender as Button;
            if (disclaimerButton != null)
            {
                Image heartImage = disclaimerButton.Template.FindName("heartImage", disclaimerButton) as Image;
                if (heartImage != null)
                {
                    LoadImage(heartImage, HEART_IMAGE_PATH);
                }
            }
        }
        private void LoadImage(Image image, string imagePath)
        {
            string commonProjectDirectory = System.IO.Path.GetDirectoryName(typeof(PluginRibbon).Assembly.Location);
            string fullPath = System.IO.Path.Combine(commonProjectDirectory, imagePath);
            Uri uri = new Uri(fullPath);
            image.Source = new BitmapImage(uri);
        }

        private void OffOn(bool toggle, string message)
        {
            applyButton.IsEnabled = toggle;
            textBox.IsHitTestVisible = toggle;
            textBox.IsEnabled = toggle;
            textBox.Text = message;
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            var s = Tools.splitString(textBox.Text);
            Tools.getElements(s);
            this.DialogResult = true;
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void onMouseEnter(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = string.Empty;
        }

        private void Title_Link(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://e-verse.com/");
        }
    }
}

using EVerse.Navisworks.Plugin.Common;
using EVerse.Navisworks.SelectByRevitId.Plugin.Utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EVerse.Navisworks.SelectByRevitId.Plugin
{
    /// <summary>
    /// Interaction logic for SelectByIdWindow.xaml
    /// </summary>
    public partial class SelectByIdWindow : Window
    {
        private const string ADDIN_IMAGE_PATH = "Images\\SelectByRevitId.png";
        private const string HEART_IMAGE_PATH = "Images\\Heart.jpg";
        private const string NO_REVIT_MODEL_MESSAGE = "No revit model available";
        private const string INSERT_ELEMENT_ID_MESSAGE = "Insert element revit ID";
        public const string PRODUCT_VERSION = "1.0.9";
        private TextBlock Placeholder;
        public SelectByIdWindow()
        {
            InitializeComponent();

            InitializeValues();
        }
        private void InitializeValues()
        {
            versionLabel.Content = string.Concat("v.", PRODUCT_VERSION);
            LoadImage(ComponentImage, ADDIN_IMAGE_PATH);
        }
        private void FindDisclaimerButtonChildImage(object sender, RoutedEventArgs e)
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
        private void FindTextBlockPlaceholderComponent(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                TextBlock placeHolder = textBox.Template.FindName("textBlockPlaceholder", textBox) as TextBlock;
                if (placeHolder != null)
                {
                    this.Placeholder = placeHolder;
                }
            }
            FreezeUI();
        }
        private bool FreezeUI()
        {
            if (!Tools.IsRevitModelLoaded())
                return OffOn(false, NO_REVIT_MODEL_MESSAGE);
            return OffOn(true, INSERT_ELEMENT_ID_MESSAGE);

        }
        private void LoadImage(Image image, string imagePath)
        {
            string commonProjectDirectory = System.IO.Path.GetDirectoryName(typeof(PluginRibbon).Assembly.Location);
            string fullPath = System.IO.Path.Combine(commonProjectDirectory, imagePath);
            Uri uri = new Uri(fullPath);
            image.Source = new BitmapImage(uri);
        }

        private bool OffOn(bool toggle, string message)
        {
            applyButton.IsEnabled = toggle;
            textBox.IsHitTestVisible = toggle;
            textBox.IsEnabled = toggle;
            this.Placeholder.Text = message;
            return toggle;
        }
        private void OkButton_Click(object sender, EventArgs e)
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

        //private void onMouseEnter(object sender, MouseButtonEventArgs e)
        //{
        //    textBox.Text = string.Empty;
        //}

        private void Title_Link(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://e-verse.com/");
        }
    }
}

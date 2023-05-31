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
        private const string INSERT_ELEMENT_ID_MESSAGE = "Insert Element ID";
        public const string PRODUCT_VERSION = "1.0.13";
        private TextBlock Placeholder;
        public SelectByIdWindow()
        {
            InitializeComponent();

            InitializeValues();
        }
        private T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Check if parent is null
            if (parent == null) return null;

            // Check if parent is the child we're looking for
            var frameworkElement = parent as FrameworkElement;
            if (frameworkElement != null && frameworkElement.Name == childName)
            {
                return parent as T;
            }

            // Recursively search for the child
            int numChildren = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numChildren; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var result = FindChild<T>(child, childName);
                if (result != null) return result;
            }

            return null;
        }

        private void FindDisclaimerButtonChildImage(object sender, RoutedEventArgs e)
        {
            Button disclaimerButton = sender as Button;
            if (disclaimerButton != null)
            {

                Image disclaimerImage = FindChild<Image>(disclaimerButton, "heartImage");
                LoadImage(disclaimerImage, HEART_IMAGE_PATH);
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
        private bool OffOn(bool toggle, string message)
        {
            applyButton.IsEnabled = toggle;
            textBox.IsHitTestVisible = toggle;
            textBox.IsEnabled = toggle;
            this.Placeholder.Text = message;
            return toggle;
        }
        private bool FreezeUI()
        {
            if (!Tools.IsRevitModelLoaded())
                return OffOn(false, NO_REVIT_MODEL_MESSAGE);
            return OffOn(true, INSERT_ELEMENT_ID_MESSAGE);

        }
        private void LoadImage(Image image, string imagePath)
        {
            string fullPath = GetImagePath(imagePath);
            Uri uri = new Uri(fullPath);
            image.Source = new BitmapImage(uri);
        }
        private static string GetImagePath(string imagePath)
        {
            string commonProjectDirectory = System.IO.Path.GetDirectoryName(typeof(PluginRibbon).Assembly.Location);
            string fullPath = System.IO.Path.Combine(commonProjectDirectory, imagePath);
            return fullPath;
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            var s = Tools.splitString(textBox.Text);
            Tools.getElements(s);
            this.DialogResult = true;
        }
        private void InitializeValues()
        {
            versionLabel.Content = string.Concat("v.", PRODUCT_VERSION);
            LoadImage(ComponentImage, ADDIN_IMAGE_PATH);
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Title_Link(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://e-verse.com/");
        }
    }
}

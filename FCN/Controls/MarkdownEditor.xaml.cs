using FCN.Core.Classes;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FCN.Controls
{
    public sealed partial class MarkdownEditor : UserControl, IEditor
    {
        public IArticleElement ArticleElement
        {
            get => (MarkdownElement)GetValue(ArticleElementProperty);
            set
            {
                SetValue(ArticleElementProperty, value);
                if ((ArticleElement as MarkdownElement).MarkdownText is not null)
                   Editor.Document.SetText(TextSetOptions.None, ((MarkdownElement)ArticleElement).MarkdownText);
            }
        }
        public static readonly DependencyProperty ArticleElementProperty =
                   DependencyProperty.Register("ArticleElement", typeof(MarkdownElement), typeof(WYSIWYGEditor), null);

        public MarkdownEditor()
        {
            this.InitializeComponent();
            MarkdownBlock.Width = Editor.Width = (((Frame)Window.Current.Content).ActualWidth - 200) / 2;
        }

        private void Editor_TextChanged(object sender, RoutedEventArgs e)
        {
            Editor.Document.GetText(TextGetOptions.None, out ((MarkdownElement)ArticleElement).MarkdownText);
            MarkdownBlock.Text = ((MarkdownElement)ArticleElement).MarkdownText;
            Undo.IsEnabled = Editor.Document.CanUndo();
            Redo.IsEnabled = Editor.Document.CanRedo();
        }

        private void Undo_Click(object sender, RoutedEventArgs e) => Editor.Document.Undo();

        private void Redo_Click(object sender, RoutedEventArgs e) => Editor.Document.Redo();
    }
}

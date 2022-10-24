using Windows.UI.Xaml.Controls;
using FCN.Core.Classes;
using Windows.UI.Xaml;
using FCN.Core.Interfaces;
using Windows.UI.Text;
using Windows.UI;
using FCN.Core.Helpers;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FCN.Controls
{
    public sealed partial class WYSIWYGEditor : UserControl, IEditor
    {
        public IArticleElement ArticleElement
        {
            get => (TextElement)GetValue(ArticleElementProperty);
            set
            {
                SetValue(ArticleElementProperty, value);
                if ((ArticleElement as TextElement).RtfText is not null)
                    Editor.Document.SetText(TextSetOptions.FormatRtf, ((TextElement)ArticleElement).RtfText);
            }
        }
        public static readonly DependencyProperty ArticleElementProperty =
                   DependencyProperty.Register("ArticleElement", typeof(TextElement), typeof(WYSIWYGEditor), null);

        public WYSIWYGEditor() => this.InitializeComponent();

        private void Editor_TextChanged(object sender, RoutedEventArgs e)
        {
            Editor.Document.GetText(TextGetOptions.FormatRtf, out ((TextElement)ArticleElement).RtfText);
            Undo.IsEnabled = Editor.Document.CanUndo();
            Redo.IsEnabled = Editor.Document.CanRedo();
        }

        private void LinkAdd_Click(object sender, RoutedEventArgs e)
        {
            if(HeaderLinkBox.Text == "")
            {
                HeaderLinkBox.Foreground = RedLinearGradientBrush;
                HeaderLinkBox.Focus(FocusState.Programmatic);
                HeaderLoadAnimation.Start();
                return;
            }
            if(LinkBox.Text == "")
            {
                LinkBox.Foreground = RedLinearGradientBrush;
                LinkBox.Focus(FocusState.Programmatic);
                LinkLoadAnimation.Start();
                return;
            }
            ITextSelection SelectedText = Editor.Document.Selection;
            SelectedText.Text = HeaderLinkBox.Text;
            SelectedText.EndPosition = SelectedText.StartPosition + HeaderLinkBox.Text.Length;
            SelectedText.Link = $"\"{LinkBox.Text}\"";
            SelectedText.CharacterFormat.ForegroundColor = (Color)Application.Current.Resources["SystemAccentColorLight1"];
            LinkFlyout.Hide();
        }

        private void Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ITextSelection SelectedText = Editor.Document.Selection;
            if(SelectedText.CharacterFormat.Italic == FormatEffect.On)
                Italy.IsChecked = true;
            else if(SelectedText.CharacterFormat.Italic == FormatEffect.Off)
                Italy.IsChecked = false;

            if (SelectedText.CharacterFormat.Bold == FormatEffect.On)
                Bold.IsChecked = true;
            else if(SelectedText.CharacterFormat.Bold == FormatEffect.Off)
                Bold.IsChecked = false;
        }

        private void Bold_Checked(object sender, RoutedEventArgs e)
        {
            ITextSelection selectedText = Editor.Document.Selection;
            if (selectedText != null)
            {
                ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = FormatEffect.On;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void Bold_UnChecked(object sender, RoutedEventArgs e)
        {
            ITextSelection selectedText = Editor.Document.Selection;
            if (selectedText != null)
            {
                ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = FormatEffect.On;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void Italic_Checked(object sender, RoutedEventArgs e)
        {
            ITextSelection selectedText = Editor.Document.Selection;
            if (selectedText != null)
            {
                ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = FormatEffect.On;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void Italic_UnChecked(object sender, RoutedEventArgs e)
        {
            ITextSelection selectedText = Editor.Document.Selection;
            if (selectedText != null)
            {
                ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = FormatEffect.On;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        // for testing purposes
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a;
            Editor.Document.GetText(TextGetOptions.FormatRtf, out a);
            Block.Text = MarkdownHelper.RtfToMarkdown(a);
        }

        private void Undo_Click(object sender, RoutedEventArgs e) => Editor.Document.Undo();

        private void Redo_Click(object sender, RoutedEventArgs e) => Editor.Document.Redo();
    }
}

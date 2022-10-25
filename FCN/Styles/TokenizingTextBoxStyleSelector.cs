using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FCN.Styles
{
    /// <summary>
    /// <see cref="StyleSelector"/> used by <see cref="TokenizingTextBox"/> to choose the proper <see cref="TokenizingTextBoxItem"/> container style (text entry or token).
    /// </summary>
    public class TokenizingTextBoxStyleSelector : StyleSelector
    {
        /// <summary>
        /// Gets or sets the <see cref="Style"/> of a token item.
        /// </summary>
        public Style TokenStyle { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Style"/> of a text entry item.
        /// </summary>
        public Style TextStyle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenizingTextBoxStyleSelector"/> class.
        /// </summary>
        public TokenizingTextBoxStyleSelector()
        {
        }

        /// <inheritdoc/>
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            if (item is ITokenStringContainer)
            {
                return TextStyle;
            }

            return TokenStyle;
        }
    }
}

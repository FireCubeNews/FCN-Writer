using CommunityToolkit.Mvvm.Messaging.Messages;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Messages
{
    public class ArticleUpdatedMessage : ValueChangedMessage<IProjectArticle>
    {
        public ArticleUpdatedMessage(IProjectArticle value) : base(value)
        {
        }
    }
}

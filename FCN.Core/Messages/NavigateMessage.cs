using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using FCN.Core.Enums;

namespace FCN.Core.Messages
{
    public class NavigateMessage : ValueChangedMessage<NavigationEnum>
    {
        public NavigateMessage(NavigationEnum value) : base(value)
        {
        }
    }
}

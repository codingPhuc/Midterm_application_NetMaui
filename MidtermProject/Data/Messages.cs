using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MidtermProject.Data;

public class RefreshMessage : ValueChangedMessage<bool>
{
    public RefreshMessage(bool value) : base(value)
    {
    }
}


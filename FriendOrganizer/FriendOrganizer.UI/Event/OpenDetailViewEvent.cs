using Prism.Events;

namespace FriendOrganizer.UI.Event
{
    public class OpenDetailViewEvent:PubSubEvent<OpenDetailViewEventEventArgs>
    {
    }
    public class OpenDetailViewEventEventArgs
    {
        public int? Id { get; set; }
        public string ViewModelName { get; set; }
    }
}

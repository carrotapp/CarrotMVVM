using Carrot.Core.ViewModels;
using MvvmCross.Plugin.Messenger;

namespace Carrot.Core.Models.DTO
{
    public class LocationMessage: MvxMessage
    {
        public Location UserLocation { get; private set; }

        public LocationMessage(object sender, Location location): base(sender)
        {
            UserLocation = location;
        }

    }
}

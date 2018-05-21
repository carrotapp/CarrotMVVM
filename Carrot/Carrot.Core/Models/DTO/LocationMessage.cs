using MvvmCross.Plugin.Messenger;

namespace Carrot.Core.Models.DTO
{
    public class LocationMessage: MvxMessage
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public LocationMessage(object sender, double lat, double lng): base(sender)
        {
            Latitude = lat;
            Longitude = lng;
        }

    }
}

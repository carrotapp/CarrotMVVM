using Carrot.Core.ViewModels;
using MvvmCross.Plugin.Location;
using System.Threading.Tasks;

namespace Carrot.Core.Services.LocationService
{
    public interface ILocationService
    {
        void OnLocation(MvxGeoLocation location);
        void OnError(MvxLocationError error);
        Task PushUserLocationToDB(Location location);
    }
}

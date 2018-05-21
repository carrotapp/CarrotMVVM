using MvvmCross.Plugin.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carrot.Core.Services.LocationService
{
    public interface ILocationService
    {
        void OnLocation(MvxGeoLocation location);
        void OnError(MvxLocationError error);
    }
}

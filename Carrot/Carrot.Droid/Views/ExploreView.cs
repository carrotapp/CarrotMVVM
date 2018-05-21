using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Carrot.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace Carrot.Droid.Views
{
    [Activity(Label = "Explore", MainLauncher = true)]
    public class ExploreView : MvxActivity<MapViewModel>, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;
        private GoogleMap _map;
        private Marker _userLocation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ExploreView);

            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;

            var options = new MarkerOptions();
            options.SetPosition(new LatLng(ViewModel.Lat, ViewModel.Lng));
            options.SetTitle("My location");
            _userLocation = _map.AddMarker(options);

            var set = this.CreateBindingSet<ExploreView, MapViewModel>();
            set.Bind(_userLocation).For(m => m.Position).To(vm => vm.UserLocation).WithConversion(new LocationToLatLngValueConverter(), null);
            set.Apply();
        }
    }
}
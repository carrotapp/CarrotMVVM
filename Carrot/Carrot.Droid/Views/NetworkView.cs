using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Carrot.Core.ViewModels;
using Carrot.Droid.ValueConverters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace Carrot.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar")]
    public class NetworkView : MvxActivity<MapViewModel>, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;
        private GoogleMap _map;
        private Marker _userLocation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NetworkView);

            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);

            //var testButton = FindViewById<FloatingActionButton>(Resource.Id.filterMenuItem);
            //testButton.Click += async (s, e) =>
            //{
            //    await ViewModel.TestDB();
            //};
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;

            var options = new MarkerOptions();
            options.SetPosition(new LatLng(ViewModel.UserLocation.Lat, ViewModel.UserLocation.Lng));
            options.SetTitle("My location");
            _userLocation = _map.AddMarker(options);

            var set = this.CreateBindingSet<NetworkView, MapViewModel>();
            set.Bind(_userLocation).For(m => m.Position).To(vm => vm.UserLocation).WithConversion(new LocationToLatLngValueConverter(), null);
            set.Apply();
        }
    }
}
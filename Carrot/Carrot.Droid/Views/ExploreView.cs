using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Carrot.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Carrot.Droid.Views
{
    [Activity(Label = "Explore", MainLauncher = true)]
    public class ExploreView : MvxActivity<MapViewModel>, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;
        private GoogleMap _map;

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

            //CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            //builder.Target(new LatLng(ViewModel.Lat, ViewModel.Lng));
            //builder.Zoom(18);
            //CameraPosition cameraPosition = builder.Build();
            //CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            //_map.MoveCamera(cameraUpdate);

            var options = new MarkerOptions();
            Bitmap bmp = BitmapFactory.DecodeResource(Resources, Resource.Mipmap.carrot);
            options.SetIcon(BitmapDescriptorFactory.FromBitmap(bmp));

            options.SetPosition(new LatLng(0, 0));
            options.SetTitle("My location");
            Marker marker = _map.AddMarker(options);
        }
    }
}
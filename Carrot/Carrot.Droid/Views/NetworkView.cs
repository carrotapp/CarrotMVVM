using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Carrot.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content.Res;
using Android.Content;
using TextDrawable;
using Clans.Fab;
using System;
using System.Collections.Generic;
using Carrot.Core.Models.DTO;
using MvvmCross.UI;

namespace Carrot.Droid.Views
{
    [Activity(MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class NetworkView : MvxActivity<MapViewModel>, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;
        private GoogleMap _map;
        private TextDrawable.TextDrawable icon;
        private Marker _userLocation;
        private List<Location> _locations;
        private List<Place> _places;

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

            var testButton = FindViewById<FloatingActionButton>(Resource.Id.checkInFab);

            testButton.Click += (s, e) =>
           {
               try
               {
                   Test();
               }
               catch (System.Exception er)
               {
                   System.Console.WriteLine(er.Message); ;
               }
           };
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            Test();

            var options = new MarkerOptions();
            options.SetPosition(new LatLng(ViewModel.UserLocation.Lat, ViewModel.UserLocation.Lng));
            options.SetTitle("My location");
            options.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.my_location));
            _userLocation = _map.AddMarker(options);

            var placeMarker = new MarkerOptions();

            for (int i = 0; i < _places.Count; i++)
            {
                placeMarker.SetPosition(new LatLng(_locations[i].Lat, _locations[i].Lng));
                placeMarker.SetTitle(_places[i].Name);
                placeMarker.SetIcon(IconDrawableToBitmap(_places[i].Name.Substring(0, 1), 100, Color.ParseColor(_places[i].Colour)));
                _map.AddMarker(placeMarker);
            }

            var set = this.CreateBindingSet<NetworkView, MapViewModel>();
            set.Bind(_userLocation).For(m => m.Position).To(vm => vm.UserLocation).WithConversion(new LocationToLatLngValueConverter(), null);
            set.Apply();
        }

        private BitmapDescriptor IconDrawableToBitmap(string label, int size, Color color)
        {
            icon = TextDrawable.TextDrawable.TextDrawbleBuilder
           .BeginConfig()
           .Height(size)
           .Width(size)
           .BorderColor(color)
           .TextColor(color)
        .WithBorder(5)
           .FontSize(50)
           .EndConfig()
           .BuildRound(label, Color.White);

            Canvas canvas = new Canvas();
            Bitmap bitmap = Bitmap.CreateBitmap(icon.IntrinsicWidth, icon.IntrinsicHeight, Bitmap.Config.Argb8888);
            canvas.SetBitmap(bitmap);
            icon.SetBounds(0, 0, canvas.Width, canvas.Height);
            icon.Draw(canvas);
            BitmapDescriptor bd = BitmapDescriptorFactory.FromBitmap(bitmap);
            return bd;
        }

        private void Test()
        {
            _places = ViewModel.DisplayMock();
            _locations = new List<Location>();
            Console.WriteLine(_places[0].Name);
            foreach (var item in _places)
            {
                _locations.Add(new Location(item.Coords));
            }
        }
    }
}
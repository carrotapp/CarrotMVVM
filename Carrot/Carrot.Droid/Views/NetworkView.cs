using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Carrot.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using Clans.Fab;

using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content.Res;
using Android.Content;
using TextDrawable;

namespace Carrot.Droid.Views
{
    [Activity(Label = "Network", MainLauncher = true)]
    public class NetworkView : MvxActivity<MapViewModel>, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;
        private GoogleMap _map;
        private TextDrawable.TextDrawable icon;
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
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);

            var testButton = FindViewById<FloatingActionButton>(Resource.Id.filterMenuItem);
            //testButton.Click += async (s, e) =>
            //{
            //    await ViewModel.TestDB();
            //};
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;

            BitmapDescriptor bd = IconDrawableToBitmap("AB", 100, Color.Orange);

            var options = new MarkerOptions();
            options.SetPosition(new LatLng(0, 0));
            options.SetTitle("My location");
            options.SetIcon(bd);
            _userLocation = _map.AddMarker(options);

            //var set = this.CreateBindingSet<NetworkView, MapViewModel>();
            //set.Bind(_userLocation).For(m => m.Position).To(vm => vm.UserLocation).WithConversion(new LocationToLatLngValueConverter(), null);
            //set.Apply();
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
    }
}
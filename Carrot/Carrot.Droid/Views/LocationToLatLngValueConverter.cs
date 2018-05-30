using System;
using System.Globalization;
using Android.Gms.Maps.Model;
using Carrot.Core.ViewModels;
using MvvmCross.Converters;

namespace Carrot.Droid.Views
{
    public class LocationToLatLngValueConverter : MvxValueConverter<Location, LatLng>
    {
        protected override LatLng Convert(Location value, Type targetType, object parameter, CultureInfo culture)
        {
            return new LatLng(value.Lat, value.Lng);
        }
    }
}
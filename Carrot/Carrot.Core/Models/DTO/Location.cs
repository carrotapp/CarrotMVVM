namespace Carrot.Core.ViewModels
{
    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public Location(string location)
        {
            var arr = location.Split(':');
            Lat = double.Parse(arr[0]);
            Lng = double.Parse(arr[1]);
        }

        public Location(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public override string ToString()
        {
            return $"{Lat}:{Lng}";
        }
    }
}

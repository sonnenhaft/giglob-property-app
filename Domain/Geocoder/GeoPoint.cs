using System;
using System.Globalization;

namespace Domain.Geocoder
{
    public struct GeoPoint
    {
        public GeoPoint(double lon, double lat)
        {
            Lon = lon;
            Lat = lat;
        }

        public GeoPoint(string lonlat) : this(0, 0)
        {
            var coords = lonlat.Split(' ');

            if (coords.Length != 2)
            {
                throw new ArgumentException("Incorrect coordinate string");
            }

            Lon = Parse(coords[0]);
            Lat = Parse(coords[1]);
        }

        public double Lat { get; }

        public double Lon { get; }

        public override int GetHashCode()
        {
            return (Lon * 1000 + Lat).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GeoPoint))
            {
                return false;
            }

            var geopoint = (GeoPoint) obj;

            return Math.Abs(geopoint.Lat - Lat) < 0.0000001 && Math.Abs(geopoint.Lon - Lon) < 0.0000001;
        }

        private double Parse(string coordDescription)
        {
            double coord;

            var success = double.TryParse(coordDescription, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out coord);

            if (!success)
            {
                throw new ArgumentException("Incorrect coordinate string");
            }

            return coord;
        }
    }
}
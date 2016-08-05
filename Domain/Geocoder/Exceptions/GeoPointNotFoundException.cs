using System;
using Domain.Exceptions;

namespace Domain.Geocoder.Exceptions
{
    public class GeoPointNotFoundException : NotFoundException
    {
        public GeoPointNotFoundException() : base("Geo point not found") { }
        public GeoPointNotFoundException(Exception innerException) : base("Geo point not found", innerException) { }
        public GeoPointNotFoundException(string message) : base(message) { }
        public GeoPointNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
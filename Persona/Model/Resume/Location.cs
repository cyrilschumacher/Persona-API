using System.Device.Location;

namespace Persona.Model.Resume
{
    /// <summary>
    ///     Represents the location.
    /// </summary>
    public class Location
    {
        /// <summary>
        ///     Gets or sets the coordinates.
        /// </summary>
        public GeoCoordinate Coordinates { get; set; }

        /// <summary>
        ///     Gets or sets the civic address.
        /// </summary>
        public CivicAddress Address { get; set; }
    }
}
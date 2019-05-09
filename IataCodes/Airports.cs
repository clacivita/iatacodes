using System;
using System.Collections.Generic;

namespace IataCodes
{
    /// <summary>
    /// The information about an individual airport.
    /// </summary>
    public partial class Airports
    {
        /// <summary>
        /// The internal unique ID of the airport.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The full name of the airport.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The city in which the airport resides.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The full country in which the airport resides.
        /// </summary>
        public string FullCountry { get; set; }

        /// <summary>
        /// The IATA code of the airport.
        /// </summary>
        public string Iatacode { get; set; }

        /// <summary>
        /// The IACO code of the airport.
        /// </summary>
        public string Icaocode { get; set; }

       /// <summary>
       /// The latitude of the airport.
       /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of the airport.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The altitude of the airport, in feet.
        /// </summary>
        public int Altitude { get; set; }

        /// <summary>
        /// The number of hours offset from UTC.
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// The daylight savings time region.
        /// </summary>
        public string Dst { get; set; }

        /// <summary>
        /// The full name of the timezone.
        /// </summary>
        public string TimezoneName { get; set; }

        /// <summary>
        /// The type of transportation entity (usually "airport").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The source of the airport data.
        /// </summary>
        public string Source { get; set; }
    }
}

using System.Collections.Generic;
using TrainTickeProject.Collection;

namespace TrainTickeProject.Repository
{
    public class RadixStationRepository : IStationRepository
    {
        /// <summary>
        /// The Radix data structure.
        /// </summary>
        private readonly Radix radix;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadixStationRepository"/> class.
        /// </summary>
        /// <param name="stations">The stations.</param>
        public RadixStationRepository(List<string> stations)
        {
            radix = new Radix(stations);
        }

        /// <summary>
        /// Gets all stations started with the name parameter value.
        /// </summary>
        /// <param name="name">The station name filter.</param>
        /// <returns>
        /// The list of stations.
        /// </returns>
        public IEnumerable<string> GetAllStartedWithName(string name)
        {
            return radix.Find(name);
        }
    }
}

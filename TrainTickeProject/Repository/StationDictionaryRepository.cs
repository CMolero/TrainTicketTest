using System.Collections.Generic;
using System.Linq;

namespace TrainTickeProject.Repository
{
    /// <summary>
    /// The  Station Dictionary Repository builds a dictionary with the station possible prefixes.
    /// This approach isn't the best one because it consumes a lot of memory.
    /// </summary>
    public class StationDictionaryRepository : IStationRepository
    {

        /// <summary>
        /// The lookup table with the station prefixes as keys and the complete stations name as values.
        /// </summary>
        private readonly Dictionary<string, IList<string>> stationsDictionary = new Dictionary<string, IList<string>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryStationRepository"/> class.
        /// </summary>
        /// <param name="stations">The stations.</param>
        public StationDictionaryRepository(IEnumerable<string> stations)
        {
            InitStationsDictionary(stations);
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
            IList<string> stations;
            stationsDictionary.TryGetValue(name, out stations);
            return stations ?? new List<string>(0);
        }

        /// <summary>
        /// Inits the stations dictionary with the provided stations names.
        /// </summary>
        /// <param name="stations">The stations.</param>
        private void InitStationsDictionary(IEnumerable<string> stations)
        {
            IEnumerable<string> orderedStations = stations.OrderBy(s => s);

            foreach (var station in orderedStations)
            {
                for (int i = 1; i <= station.Length; i++)
                {
                    var prefix = station.Remove(i, station.Length - i);

                    IList<string> collection;
                    if (!stationsDictionary.TryGetValue(prefix, out collection))
                    {
                        collection = new List<string>();
                        stationsDictionary.Add(prefix, collection);
                    }

                    collection.Add(station);
                }
            }
        }
    }
}


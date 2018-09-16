using System.Linq;
using TrainTickeProject.Repository;
using TrainTickeProject.Result;

namespace TrainTickeProject.StationSearch
{
    // <summary>
    /// The Station Search
    /// </summary>
    public class StationSearch : IStationSearch
    {
        /// <summary>
        /// The station repository used to access data.
        /// </summary>
        private readonly IStationRepository stationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationSearch"/> class.
        /// </summary>
        /// <param name="stationRepository">The station repository.</param>
        public StationSearch(IStationRepository stationRepository)
        {
            this.stationRepository = stationRepository;
        }

        /// <summary>
        /// Searches the station started with the name parameter value.
        /// </summary>
        /// <param name="name">The station name filter.</param>
        /// <returns>
        /// The <see cref="StationSearchResult"/> containing the collection of stations and the next available chars.
        /// </returns>
        public Result.StationSearchResult SearchStartingWith(string name)
        {
            var stations = stationRepository.GetAllStartedWithName(name);

            var nextPossibleChars = stations
                .Where(station => station.Length > name.Length)
                .Select(station => station[name.Length]);

            return new StationSearchResult(nextPossibleChars, stations);
        }
    }
}

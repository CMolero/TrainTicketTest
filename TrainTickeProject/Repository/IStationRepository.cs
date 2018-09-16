using System.Collections.Generic;

namespace TrainTickeProject.Repository
{
    public interface IStationRepository
    {
        /// <summary>
        /// Gets all stations started with the name parameter value.
        /// </summary>
        /// <param name="name">The station name filter.</param>
        /// <returns>The list of stations.</returns>
        IEnumerable<string> GetAllStartedWithName(string name);
    }
}

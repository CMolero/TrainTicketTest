using TrainTickeProject.Result;
namespace TrainTickeProject.StationSearch
{
    /// <summary>
    /// Defines contract.
    /// </summary>
    interface IStationSearch
    {
        /// <summary>
        /// Searches the station started with the name parameter value.
        /// </summary>
        /// <param name="name">The station name filter.</param>
        /// <returns> The <see cref="StationSearchResult"/> containing the collection of stations and the next available chars. </returns>
        StationSearchResult SearchStartingWith(string name);
    }
}

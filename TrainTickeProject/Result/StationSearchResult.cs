using System.Collections.Generic;
using System.Linq;

namespace TrainTickeProject.Result
{
    /// <summary>
    /// Encapsulate station search result.
    /// </summary>
    public class StationSearchResult
    {
        /// <summary>
        /// Gets the next possible characters on the available stations.
        /// </summary>
        public StationSearchResult(IEnumerable<char> nextChars, IEnumerable<string> stations)
        {
            NextChars = nextChars ?? new char[0];
            Stations = stations ?? new string[0];
        }
        public IEnumerable<char> NextChars { get; private set; }
        /// <summary>
        /// Gets the next possible characters on the available stations.
        /// </summary>
        public IEnumerable<string> Stations { get; private set; }
        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Check if are the same object
            if (this == obj)
                return true;

            var other = (StationSearchResult)obj;

            return NextChars.SequenceEqual(other.NextChars) && Stations.SequenceEqual(other.Stations);
        }
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return NextChars.GetHashCode() ^ Stations.GetHashCode();
        }
    }
}

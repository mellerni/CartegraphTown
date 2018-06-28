namespace CartegraphTown.Model.DTO
{
    public class PointDto
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Latitude of location
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude of location
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// True if one or more citizens is at that location
        /// </summary>
        public bool IsCitizenLocation { get; set; }

        /// <summary>
        /// Number of issues at location
        /// </summary>
        public int IssueCount { get; set; }
    }
}

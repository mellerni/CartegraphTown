namespace CartegraphTown.Model.DTO
{
    using System;

    public class AddressDto
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Address line one of location
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address line two of location
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// City of location
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Location's state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Location's state id
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Zip code of location [45678 or 45678-9010] 
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Date when location was created
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Lat and Long of address
        /// </summary>
        public PointDto Point { get; set; }

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

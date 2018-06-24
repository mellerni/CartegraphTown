namespace CartegraphTown.Model.DTO
{
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
        /// Zip code of location [45678 or 45678-9010] 
        /// </summary>
        public string ZipCode { get; set; }
    }
}

namespace CartegraphTown.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using Base.Implementations;

    public class Location : TrackedEntity<int>
    {
        // required by EF
        protected Location()
        {
            this.Issues = new HashSet<Issue>();
            this.Citizens = new HashSet<Citizen>();
        }

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
        /// Foreign key of location's state
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Zip code of location [45678 or 45678-9010] 
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Latitude of location
        /// </summary>
        public float? Latitude { get; set; }

        /// <summary>
        /// Longitude of location
        /// </summary>
        public float? Longitude { get; set; }

        /// <summary>
        /// State of location
        /// </summary>
        public virtual State State { get; set; }

        /// <summary>
        /// Collection of issues
        /// </summary>
        public virtual ICollection<Issue> Issues { get; set; }

        /// <summary>
        /// Collection of citizens
        /// </summary>
        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}

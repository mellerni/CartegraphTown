namespace CartegraphTown.Model.Entity
{
    using System.Collections.Generic;
    using Base.Implementations;

    public class Citizen : TrackedEntity<int> 
    {
        // required by EF
        protected Citizen()
        {
            this.Issues = new HashSet<Issue>();
        }

        /// <summary>
        /// Citizen first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Citizen last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Citizen email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Citizen phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Foreign key of citizen's location
        /// </summary>
        public int LocationId { get; set; }


        /// <summary>
        /// Current physical address of citizen
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Collection of child locations
        /// </summary>
        public virtual ICollection<Issue> Issues { get; set; }

        /// <summary>
        /// Citizen full name
        /// </summary>
        public string FullName => this.LastName + ", " + this.FirstName;

        /// <summary>
        /// Citizen type ahead
        /// </summary>
        public string GetTypeAhead()
        {
            var typeAhead = "Name: " + this.FullName;
            if (this.Location?.Address1 != null)
            {
                typeAhead += " - Address: " + this.Location.Address1;
            }

            return typeAhead;
        }
    }
}

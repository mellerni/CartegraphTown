namespace CartegraphTown.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using Base.Implementations;
    using DTO;

    public class Citizen : TrackedEntity<int> 
    {
        // required by EF
        protected Citizen()
        {
            this.Issues = new HashSet<Issue>();
        }

        public Citizen(CitizenDto model)
        {
            this.Validate(model);
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Email = model.Email;
            this.Phone = model.Phone;
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
        public int? LocationId { get; set; }


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
            var typeAhead = "Name: " + this.FirstName + " " + this.LastName;
            if (this.Location?.Address1 != null)
            {
                typeAhead += " - Address: " + this.Location.Address1;
            }

            return typeAhead;
        }

        public void Update(CitizenDto model)
        {
            this.Validate(model);
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Email = model.Email;
            this.Phone = model.Phone;
        }

        private void Validate(CitizenDto model)
        {
            if (string.IsNullOrEmpty(model.FirstName) || model.FirstName.Length > 250)
            {
                throw new ArgumentException("First name is required and must be 250 characters or less.");
            }

            if (string.IsNullOrEmpty(model.LastName) || model.LastName.Length > 250)
            {
                throw new ArgumentException("Last name is required and must be 250 characters or less.");
            }

            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Phone))
            {
                throw new ArgumentException("Some form of contact info is required. Phone, email, or both.");
            }

            if (!string.IsNullOrWhiteSpace(model.Email) && model.Email.Length > 250)
            {
                throw new ArgumentException("Email must be 250 characters or less.");
            }

            if (!string.IsNullOrWhiteSpace(model.Phone) && model.Phone.Length > 50)
            {
                throw new ArgumentException("Phone must be 50 characters or less.");
            }
        }
    }
}

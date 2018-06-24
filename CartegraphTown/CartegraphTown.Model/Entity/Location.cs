namespace CartegraphTown.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Base.Implementations;
    using DTO;

    public class Location : TrackedEntity<int>
    {
        // required by EF
        protected Location()
        {
            this.Issues = new HashSet<Issue>();
            this.Citizens = new HashSet<Citizen>();
        }

        public Location(AddressDto model)
        {
            this.Validate(model);
            this.Address1 = model.Address1;
            this.Address2 = model.Address2;
            this.City = model.City;
            this.StateId = model.StateId;
            this.ZipCode = model.ZipCode;
        }

        public Location(PointDto model)
        {
            this.Validate(model);
            this.Latitude = model.Latitude;
            this.Longitude = model.Longitude;
        }

        public Location(AddressDto addressModel, PointDto pointModel) : this(addressModel)
        {
            this.Validate(pointModel);
            this.Latitude = pointModel.Latitude;
            this.Longitude = pointModel.Longitude;
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

        public void Update(AddressDto model)
        {
            this.Validate(model);
            this.Address1 = model.Address1;
            this.Address2 = model.Address2;
            this.City = model.City;
            this.StateId = model.StateId;
            this.ZipCode = model.ZipCode;
        }

        public void Update(PointDto model)
        {
            this.Validate(model);
            this.Latitude = model.Latitude;
            this.Longitude = model.Longitude;
        }

        public void Update(AddressDto addressModel, PointDto pointModel)
        {
            this.Update(addressModel);
            this.Update(pointModel);
        }

        private void Validate(AddressDto model)
        {
            if (model.StateId <= 0)
            {
                throw new ArgumentException("State is required.");
            }

            if (string.IsNullOrEmpty(model.Address1) || model.Address1.Length > 250)
            {
                throw new ArgumentException("Address line one is required and must be 250 characters or less.");
            }

            if (!string.IsNullOrWhiteSpace(model.Address2) && model.Address2.Length > 250)
            {
                throw new ArgumentException("Address line two must be 250 characters or less.");
            }

            if (string.IsNullOrEmpty(model.City) || model.City.Length > 250)
            {
                throw new ArgumentException("City is required and must be 250 characters or less.");
            }

            if (string.IsNullOrEmpty(model.ZipCode) || model.ZipCode.Length > 50)
            {
                throw new ArgumentException("Zip code is required and must be 50 characters or less.");
            }
        }

        private void Validate(PointDto model)
        {
            // Valid Latitude for 95% of North America
            if (model.Latitude <= 15.0000 || model.Latitude >= 75.0000)
            {
                throw new ArgumentException("Latitude is invalid.");
            }

            // Valid Longitude for 95% of North America
            if (model.Longitude <= 50.0000 || model.Longitude >= 180.0000)
            {
                throw new ArgumentException("Longitude is invalid.");
            }

            var latPrecision = model.Latitude.ToString(CultureInfo.InvariantCulture).Split('.')[1].Length;
            if (latPrecision < 4)
            {
                throw new ArgumentException("Latitude is not precise enough. Please include 4 decimal places.");
            }

            var longPrecision = model.Longitude.ToString(CultureInfo.InvariantCulture).Split('.')[1].Length;
            if (longPrecision < 4)
            {
                throw new ArgumentException("Longitude is not precise enough. Please include 4 decimal places.");
            }
        }
    }
}

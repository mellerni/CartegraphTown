﻿namespace CartegraphTown.Model.Entity
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

        public Location(AddressDto model) : this(model.Point)
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
            if (model != null && (model.Latitude.HasValue || model.Longitude.HasValue))
            {
                this.Validate(model);
                this.Latitude = model.Latitude;
                this.Longitude = model.Longitude;
            }
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
        public int? StateId { get; set; }

        /// <summary>
        /// Zip code of location [45678 or 45678-9010] 
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Latitude of location
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude of location
        /// </summary>
        public double? Longitude { get; set; }

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

        public string GetLocationDescription()
        {
            if (this.StateId.HasValue)
            {
                return $"Address: {this.Address1} {this.Address2} {this.City}, {this.State.Abbreviation} {this.ZipCode}";
            }

            return $"Point: [ Lat: {this.Latitude} Long: {this.Longitude} ]";
        }

        public void Update(AddressDto model)
        {
            this.Validate(model);
            this.Address1 = model.Address1;
            this.Address2 = model.Address2;
            this.City = model.City;
            this.StateId = model.StateId;
            this.ZipCode = model.ZipCode;

            if (model.Point.Latitude.HasValue || model.Point.Longitude.HasValue)
            {
                this.Update(model.Point);
            }
        }

        public void Update(PointDto model)
        {
            if (model != null)
            {
                this.Validate(model);
                this.Latitude = model.Latitude;
                this.Longitude = model.Longitude;
            }
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
            if (!model.Latitude.HasValue)
            {
                throw new ArgumentException("Latitude is required.");
            }

            if (!model.Longitude.HasValue)
            {
                throw new ArgumentException("Longitude is required.");
            }
        }
    }
}
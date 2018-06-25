namespace CartegraphTown.Model.DTO
{
    using System;

    public class CitizenDto
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

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
        /// Date when citizen was created
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
    }
}

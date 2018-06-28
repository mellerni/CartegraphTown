namespace CartegraphTown.Model.DTO
{
    using System;
    using Enum;

    public class IssueDto
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of issue description
        /// </summary>
        public string IssueTypeDescription { get; set; }

        /// <summary>
        /// Type of issue
        /// </summary>
        public IssueType IssueTypeId { get; set; }


        /// <summary>
        /// Citizen's full name reporting the issue
        /// </summary>
        public string Citizen { get; set; }

        /// <summary>
        /// Citizen's id reporting the issue
        /// </summary>
        public int CitizenId { get; set; }

        /// <summary>
        /// Short location description
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Location id where the issue occurred
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Issue details or description
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Corrective action taken for issue
        /// </summary>
        public string CorrectiveAction { get; set; }

        /// <summary>
        /// Date when corrective action was taken for issue
        /// </summary>
        public DateTimeOffset? CorrectionDate { get; set; }

        /// <summary>
        /// Date when issue was created
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
    }
}

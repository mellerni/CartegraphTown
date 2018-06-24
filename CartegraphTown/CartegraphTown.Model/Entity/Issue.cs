namespace CartegraphTown.Model.Entity
{
    using System;
    using Base.Implementations;
    using Enum;

    public class Issue : TrackedEntity<int>
    {
        // required by EF
        protected Issue()
        {
        }

        /// <summary>
        /// Type of issue
        /// </summary>
        public IssueType IssueType { get; set; }

        /// <summary>
        /// Foreign key of issue's location
        /// </summary>
        public int LocationId { get; set; }


        /// <summary>
        /// Foreign key of citizen reporting the issue
        /// </summary>
        public int CitizenId { get; set; }


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
        public DateTime CorrectionDate { get; set; }

        /// <summary>
        /// Current location of issue
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Citizen reporting the issue
        /// </summary>
        public virtual Citizen Citizen { get; set; }

    }
}

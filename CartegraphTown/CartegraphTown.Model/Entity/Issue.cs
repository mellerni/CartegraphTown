namespace CartegraphTown.Model.Entity
{
    using System;
    using Base.Implementations;
    using DTO;
    using Enum;

    public class Issue : TrackedEntity<int>
    {
        // required by EF
        protected Issue()
        {
        }

        public Issue(IssueDto model)
        {
            this.Validate(model);
            this.IssueType = model.IssueType;
            this.Details = model.Details;
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
        public DateTime? CorrectionDate { get; set; }

        /// <summary>
        /// Current location of issue
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Citizen reporting the issue
        /// </summary>
        public virtual Citizen Citizen { get; set; }

        /// <summary>
        /// True if corrective action has been taken
        /// </summary>
        public bool HasBeenCorrected => this.CorrectionDate.HasValue;

        public void Update(IssueDto model)
        {
            this.Validate(model);
            this.IssueType = model.IssueType;
            this.Details = model.Details;

            if (!string.IsNullOrWhiteSpace(model.CorrectiveAction))
            {
                this.CorrectionDate = DateTime.UtcNow;
            }
        }

        private void Validate(IssueDto model)
        {
            if (model.LocationId <= 0)
            {
                throw new ArgumentException("Location is required.");
            }

            if (model.CitizenId <= 0)
            {
                throw new ArgumentException("Citizen reporting the issue is required.");
            }

            if (model.IssueType == IssueType.None)
            {
                throw new ArgumentException("IssueType is required.");
            }

            if (!string.IsNullOrWhiteSpace(model.Details) && model.Details.Length > 4000)
            {
                throw new ArgumentException("Details must be 4000 characters or less.");
            }
        }

    }
}

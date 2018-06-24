namespace CartegraphTown.Model.Entity.Base.Implementations
{
    using System;
    using Interfaces;

    /// <summary>
    /// Abstract entity for adding standard traceable properties to an entity
    /// Adds CreatedDate, CreatedBy, UpdatedDate, and UpdatedBy
    /// </summary>
    public abstract class TrackedEntity<T> : TrackCreateEntity<T>, ITrackedEntity
    {
        /// <summary>
        /// Date entity was created
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// User id whom created the entity
        /// </summary>
        public int? UpdatedBy { get; set; }
    }
}

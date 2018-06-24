namespace CartegraphTown.Model.Entity.Base.Implementations
{
    using System;
    using Interfaces;

    public abstract class TrackCreateEntity<T> : EntityBase<T>,  ITrackCreateEntity
    {
        /// <summary>
        /// Date entity was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// User id whom created the entity
        /// </summary>
        public int CreatedBy { get; set; }
    }
}

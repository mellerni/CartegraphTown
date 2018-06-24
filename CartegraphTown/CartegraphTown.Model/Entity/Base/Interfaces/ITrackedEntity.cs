namespace CartegraphTown.Model.Entity.Base.Interfaces
{
    using System;

    public interface ITrackedEntity
    {
        /// <summary>
        /// Date entity was created
        /// </summary>
        DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// User id whom created the entity
        /// </summary>
        int? UpdatedBy { get; set; }

        /// <summary>
        /// Date entity was created
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// User id whom created the entity
        /// </summary>
        int CreatedBy { get; set; }
    }
}
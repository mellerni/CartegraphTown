namespace CartegraphTown.Model.Entity.Base.Interfaces
{
    using System;

    public interface ITrackCreateEntity
    {
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
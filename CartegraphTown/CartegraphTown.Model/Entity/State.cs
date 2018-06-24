namespace CartegraphTown.Model.Entity
{
    using System.Collections.Generic;
    using Base.Implementations;

    public class State : EntityBase<int>
    {
        // required by EF
        protected State()
        {
            this.Locations = new HashSet<Location>();
        }

        /// <summary>
        /// State abbreviation
        /// </summary>
        public string Abbreviation { get; set; }
        
        /// <summary>
        /// State full name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of child locations
        /// </summary>
        public virtual ICollection<Location> Locations { get; set; }

    }
}

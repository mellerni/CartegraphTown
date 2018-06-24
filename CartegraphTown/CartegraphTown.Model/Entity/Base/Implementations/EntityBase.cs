namespace CartegraphTown.Model.Entity.Base.Implementations
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }

        public virtual bool IsNew()
        {
            var defaultValue = default(TKey);

            if (defaultValue == null || defaultValue.Equals(this.Id))
            {
                return true;
            }

            return false;
        }
    }
}

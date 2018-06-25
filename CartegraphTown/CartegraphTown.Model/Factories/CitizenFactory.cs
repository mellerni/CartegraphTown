namespace CartegraphTown.Model.Factories
{
    using DTO;
    using Entity;

    public static class CitizenFactory
    {
        public static CitizenDto Create(Citizen entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CitizenDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                CreatedDate = entity.CreatedDate
            };
        }
    }
}

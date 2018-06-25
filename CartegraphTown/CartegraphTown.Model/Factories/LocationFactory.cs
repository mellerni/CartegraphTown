namespace CartegraphTown.Model.Factories
{
    using DTO;
    using Entity;

    public static class LocationFactory
    {
        public static AddressDto Address(Location entity)
        {
            if (entity == null)
            {
                return null;
            }

            var address = new AddressDto()
            {
                Id = entity.Id,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                City = entity.City,
                State = entity.State?.Abbreviation,
                StateId = entity.State?.Id ?? 0,
                ZipCode = entity.ZipCode,
                CreatedDate = entity.CreatedDate
            };

            address.Point = Point(entity);

            return address;
        }

        public static PointDto Point(Location entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (entity.Latitude != null && entity.Longitude != null)
            {
                return new PointDto()
                {
                    Latitude = entity.Latitude ?? default(float),
                    Longitude = entity.Longitude ?? default(float)
                };
            }

            return null;
        }
    }
}

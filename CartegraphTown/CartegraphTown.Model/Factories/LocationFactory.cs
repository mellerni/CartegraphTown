namespace CartegraphTown.Model.Factories
{
    using System.Linq;
    using DTO;
    using DTO.Common;
    using Entity;

    public static class LocationFactory
    {
        public static AddressDto Address(Location entity)
        {
            if (entity == null)
            {
                return null;
            }

            var isCitizenLocation = entity.Citizens.Any();
            var issueCount = entity.Issues.Count();
            var address = new AddressDto()
            {
                Id = entity.Id,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                City = entity.City,
                State = entity.State?.Abbreviation,
                StateId = entity.State?.Id ?? 0,
                ZipCode = entity.ZipCode,
                CreatedDate = entity.CreatedDate,
                IsCitizenLocation = isCitizenLocation,
                IssueCount = issueCount
            };

            address.Point = Point(entity) ?? new PointDto();

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
                var isCitizenLocation = entity.Citizens.Any();
                var issueCount = entity.Issues.Count();
                return new PointDto()
                {
                    Id = entity.Id,
                    Latitude = entity.Latitude ?? default(float),
                    Longitude = entity.Longitude ?? default(float),
                    IsCitizenLocation = isCitizenLocation,
                    IssueCount = issueCount
                };
            }

            return null;
        }

        public static StateDto State(State entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new StateDto()
            {
                Id = entity.Id,
                Abbreviation = entity.Abbreviation
            };
        }

        public static TypeAheadDto TypeAhead(Location entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TypeAheadDto()
            {
                Id = entity.Id,
                Description = entity.GetLocationDescription()
            };
        }
    }
}

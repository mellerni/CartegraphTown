namespace CartegraphTown.Model.Factories
{
    using DTO;
    using Entity;
    using Helpers;

    public static class IssueFactory
    {
        public static IssueDto Create(Issue entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new IssueDto()
            {
                Id = entity.Id,
                IssueTypeDescription = entity.IssueType.GetDescription(),
                IssueTypeId = entity.IssueType,
                CitizenId = entity.Citizen?.Id ?? 0,
                Citizen = entity.Citizen?.FullName,
                LocationId = entity.Location?.Id ?? 0,
                Location = entity.Location?.GetLocationDescription(),
                Details = entity.Details,
                CorrectiveAction = entity.CorrectiveAction,
                CorrectionDate = entity.CorrectionDate,
                CreatedDate = entity.CreatedDate
            };
        }
    }
}

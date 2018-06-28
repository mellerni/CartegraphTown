namespace CartegraphTown.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.DTO;
    using Model.DTO.Common;

    public interface ICitizenService
    {
        /// <summary>
        /// Get citizens type ahead
        /// </summary>
        /// <returns></returns>
        Task<Result<IEnumerable<TypeAheadDto>>> GetCitizenTypeAheadAsync();

        /// <summary>
        /// Retrieves single citizen by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<CitizenDto>> GetCitizenAsync(int id);

        /// <summary>
        /// Retrieves all citizens.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<IEnumerable<CitizenDto>>> GetAllCitizensAsync();

        /// <summary>
        /// Creates new citizen.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<int>> CreateAsync(CitizenDto model);

        /// <summary>
        /// Add location to existing citizen
        /// </summary>
        /// <param name="citizenId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        Task<ResultBase> AddLocation(int citizenId, int locationId);

        /// <summary>
        /// Update existing citizen.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResultBase> UpdateAsync(CitizenDto model);

        /// <summary>
        /// Delete existing citizen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResultBase> DeleteAsync(int id);
    }
}
namespace CartegraphTown.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.DTO;
    using Model.DTO.Common;

    public interface ICitizenService
    {
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
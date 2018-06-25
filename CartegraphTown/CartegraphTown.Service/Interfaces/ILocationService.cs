namespace CartegraphTown.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.DTO;
    using Model.DTO.Common;

    public interface ILocationService
    {
        /// <summary>
        /// Retrieves single address location by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<AddressDto>> GetLocationAsAddressAsync(int id);

        /// <summary>
        /// Retrieves single point location by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<PointDto>> GetLocationAsPointAsync(int id);

        /// <summary>
        /// Retrieves all locations as addresses.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<IEnumerable<AddressDto>>> GetAllLocationsAsAddressesAsync();

        /// <summary>
        /// Retrieves all locations as points.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<IEnumerable<PointDto>>> GetAllLocationsAsPointsAsync();

        /// <summary>
        /// Creates new location from AddressDto.
        /// </summary>
        /// <param name="model">AddressDto</param>
        /// <returns></returns>
        Task<ResultBase> CreateAsync(AddressDto model);

        /// <summary>
        /// Creates new location from PointDto.
        /// </summary>
        /// <param name="model">PointDto</param>
        /// <returns></returns>
        Task<ResultBase> CreateAsync(PointDto model);

        /// <summary>
        /// Update existing location from AddressDto.
        /// </summary>
        /// <param name="model">AddressDto</param>
        /// <returns></returns>
        Task<ResultBase> UpdateAsync(AddressDto model);

        /// <summary>
        /// Update existing location from PointDto.
        /// </summary>
        /// <param name="model">PointDto</param>
        /// <returns></returns>
        Task<ResultBase> UpdateAsync(PointDto model);

        /// <summary>
        /// Delete existing location.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResultBase> DeleteAsync(int id);
    }
}
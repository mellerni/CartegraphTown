namespace CartegraphTown.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.DTO;
    using Model.DTO.Common;

    public interface IIssueService
    {
        /// <summary>
        /// Retrieves single issue by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<IssueDto>> GetIssueAsync(int id);

        /// <summary>
        /// Retrieves all issue.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<IEnumerable<IssueDto>>> GetAllIssuesAsync();

        /// <summary>
        /// Creates new issue.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResultBase> CreateAsync(IssueDto model);

        /// <summary>
        /// Update existing issue.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResultBase> UpdateAsync(IssueDto model);

        /// <summary>
        /// Delete existing issue.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResultBase> DeleteAsync(int id);
    }
}
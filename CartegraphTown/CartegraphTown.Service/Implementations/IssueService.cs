namespace CartegraphTown.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model;
    using Model.DTO;
    using Model.DTO.Common;
    using Model.Entity;
    using Model.Factories;
    using Serilog;

    public class IssueService : ServiceBase, IIssueService
    {
        public IssueService(ICartegraphTownContext db)
        {
            this.Db = db;
        }

        /// <summary>
        /// Retrieves single issue by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<IssueDto>> GetIssueAsync(int id)
        {
            try
            {
                var issue = await this.Db.Issues.SingleOrDefaultAsync(x => x.Id == id);
                if (issue == null)
                {
                    return Result<IssueDto>.Failure("Issue not found.");
                }

                return Result<IssueDto>.Success(IssueFactory.Create(issue));
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get Issue method.");
                return Result<IssueDto>.Failure("Error in Get Issue method.");
            }
        }

        /// <summary>
        /// Retrieves all issue.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<IEnumerable<IssueDto>>> GetAllIssuesAsync()
        {
            try
            {
                // TODO: Add filtering
                var issues = await this.Db.Issues.ToListAsync();
                var issuesDtos = issues.Select(IssueFactory.Create);
                return Result<IEnumerable<IssueDto>>.Success(issuesDtos);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get All Issues method.");
                return Result<IEnumerable<IssueDto>>.Failure("Error in Get All Issue method.");
            }
        }

        /// <summary>
        /// Creates new issue.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultBase> CreateAsync(IssueDto model)
        {
            try
            {
                if (model == null)
                {
                    return ResultBase.Failure("Model is empty.");
                }

                var citizen = await this.Db.Citizens.SingleOrDefaultAsync(x => x.Id == model.CitizenId);
                if (citizen == null)
                {
                    return ResultBase.Failure("Citizen not found. Citizen is required to create a new issue.");
                }


                var location = await this.Db.Locations.SingleOrDefaultAsync(x => x.Id == model.LocationId);
                if (location == null)
                {
                    return ResultBase.Failure("Location not found. Location is required to create a new issue.");
                }

                var issue = new Issue(model);
                this.Db.Issues.Add(issue);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (ArgumentException argumentException)
            {
                return ResultBase.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Issue Create method.");
                return ResultBase.Failure($"Error in Issue Create method.");
            }
        }

        /// <summary>
        /// Update existing issue.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultBase> UpdateAsync(IssueDto model)
        {
            try
            {
                if (model == null)
                {
                    return ResultBase.Failure("Model is empty.");
                }

                var citizen = await this.Db.Citizens.SingleOrDefaultAsync(x => x.Id == model.CitizenId);
                if (citizen == null)
                {
                    return ResultBase.Failure("Citizen not found. Citizen is required to update an existing issue.");
                }


                var location = await this.Db.Locations.SingleOrDefaultAsync(x => x.Id == model.LocationId);
                if (location == null)
                {
                    return ResultBase.Failure("Location not found. Location is required to update an existing issue.");
                }


                var issue = await this.Db.Issues.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (issue == null)
                {
                    return ResultBase.Failure("Issue not found.");
                }

                issue.Update(model);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (ArgumentException argumentException)
            {
                return ResultBase.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Issue Update method.");
                return ResultBase.Failure($"Error in Issue Update method.");
            }
        }

        /// <summary>
        /// Delete existing issue.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResultBase> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ResultBase.Failure("Invalid id.");
                }

                var issue = await this.Db.Issues.SingleOrDefaultAsync(x => x.Id == id);
                if (issue == null)
                {
                    return ResultBase.Failure("Issue not found.");
                }

                this.Db.Issues.Remove(issue);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Issue Delete method.");
                return ResultBase.Failure($"Error in Issue Delete method.");
            }
        }

    }
}

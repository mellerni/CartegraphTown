namespace CartegraphTown.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Model;
    using Model.DTO;
    using Model.DTO.Common;
    using Model.Entity;
    using Model.Factories;
    using Serilog;

    public class CitizenService : ServiceBase, ICitizenService
    {
        public CitizenService(ICartegraphTownContext db)
        {
            this.Db = db;
        }

        /// <summary>
        /// Retrieves single citizen by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<CitizenDto>> GetCitizenAsync(int id)
        {
            try
            {
                var citizen = await this.Db.Citizens.SingleOrDefaultAsync(x => x.Id == id);
                if (citizen == null)
                {
                    return Result<CitizenDto>.Failure("Citizen not found.");
                }

                return Result<CitizenDto>.Success(CitizenFactory.Create(citizen));
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get Citizen method.");
                return Result<CitizenDto>.Failure("Error in Get Citizen method.");
            }
        }

        /// <summary>
        /// Retrieves all citizens.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<IEnumerable<CitizenDto>>> GetAllCitizensAsync()
        {
            try
            {
                // TODO: Add filtering
                var citizens = await this.Db.Citizens.ToListAsync();
                var citizensDtos = citizens.Select(CitizenFactory.Create);
                return Result<IEnumerable<CitizenDto>>.Success(citizensDtos);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get All Citizens method.");
                return Result<IEnumerable<CitizenDto>>.Failure("Error in Get All Citizen method.");
            }
        }

        /// <summary>
        /// Creates new citizen.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<int>> CreateAsync(CitizenDto model)
        {
            try
            {
                if (model == null)
                {
                    return Result<int>.Failure("Model is empty.");
                }

                var citizen = new Citizen(model);
                this.Db.Citizens.Add(citizen);
                await this.Db.SaveChangesAsync();
                return Result<int>.Success(citizen.Id);
            }
            catch (ArgumentException argumentException)
            {
                return Result<int>.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Citizen Create method.");
                return Result<int>.Failure($"Error in Citizen Create method.");
            }
        }

        /// <summary>
        /// Update existing citizen.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultBase> UpdateAsync(CitizenDto model)
        {
            try
            {
                if (model == null)
                {
                    return ResultBase.Failure("Model is empty.");
                }

                var citizen = await this.Db.Citizens.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (citizen == null)
                {
                    return ResultBase.Failure("Citizen not found.");
                }

                citizen.Update(model);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (ArgumentException argumentException)
            {
                return ResultBase.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Citizen Update method.");
                return ResultBase.Failure($"Error in Citizen Update method.");
            }
        }

        /// <summary>
        /// Delete existing citizen.
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

                var citizen = await this.Db.Citizens.SingleOrDefaultAsync(x => x.Id == id);
                if (citizen == null)
                {
                    return ResultBase.Failure("Citizen not found.");
                }

                this.Db.Citizens.Remove(citizen);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Citizen Delete method.");
                return ResultBase.Failure($"Error in Citizen Delete method.");
            }
        }
    }
}

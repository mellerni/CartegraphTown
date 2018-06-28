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

    public class LocationService : ServiceBase, ILocationService
    {
        public LocationService(ICartegraphTownContext db)
        {
            this.Db = db;
        }

        /// <summary>
        /// Get location type ahead
        /// </summary>
        /// <returns></returns>
        public async Task<Result<IEnumerable<TypeAheadDto>>> GetLocationTypeAheadAsync()
        {
            try
            {
                var locations = await this.Db.Locations.ToListAsync();
                var locationTypeAhead = locations.Select(LocationFactory.TypeAhead).OrderBy(x => x.Description).ToList();

                return Result<IEnumerable<TypeAheadDto>>.Success(locationTypeAhead);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get Location Type Ahead method.");
                return Result<IEnumerable<TypeAheadDto>>.Failure("Error in Get Location Type Ahead method.");
            }
        }

        /// <summary>
        /// Retrieves single address location by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<AddressDto>> GetLocationAsAddressAsync(int id)
        {
            try
            {
                var location = await this.Db.Locations
                    .Include(x => x.Issues)
                    .Include(x => x.Citizens)
                    .SingleOrDefaultAsync(x => x.Id == id);
                if (location == null)
                {
                    return Result<AddressDto>.Failure("Location not found.");
                }

                return Result<AddressDto>.Success(LocationFactory.Address(location));
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get Location as Address method.");
                return Result<AddressDto>.Failure("Error in Get Location as Address method.");
            }
        }

        /// <summary>
        /// Retrieves single point location by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<PointDto>> GetLocationAsPointAsync(int id)
        {
            try
            {
                var location = await this.Db.Locations
                    .Include(x => x.Issues)
                    .Include(x => x.Citizens)
                    .SingleOrDefaultAsync(x => x.Id == id);
                if (location == null)
                {
                    return Result<PointDto>.Failure("Location not found.");
                }

                return Result<PointDto>.Success(LocationFactory.Point(location));
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get Location as Point method.");
                return Result<PointDto>.Failure("Error in Get Location as Point method.");
            }
        }

        /// <summary>
        /// Retrieves all states as dictionary for drop down.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<IEnumerable<StateDto>>> GetStates()
        {
            try
            {
                var states = await this.Db.States.ToListAsync();
                var stateDtos = states.Select(LocationFactory.State);
                return Result<IEnumerable<StateDto>>.Success(stateDtos);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get All States method.");
                return Result<IEnumerable<StateDto>>.Failure("Error in Get All States method.");
            }
        }

        /// <summary>
        /// Retrieves all locations as addresses.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<IEnumerable<AddressDto>>> GetAllLocationsAsAddressesAsync()
        {
            try
            {
                // TODO: Add filtering
                var locations = await this.Db.Locations
                    .Include(x => x.Issues)
                    .Include(x => x.Citizens)
                    .Where(x => x.StateId.HasValue).ToListAsync();
                var addressDtos = locations.Select(LocationFactory.Address);
                return Result<IEnumerable<AddressDto>>.Success(addressDtos);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get All Locations as Addresses method.");
                return Result<IEnumerable<AddressDto>>.Failure("Error in Get All Locations as Addresses method.");
            }
        }

        /// <summary>
        /// Retrieves all locations as points.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<IEnumerable<PointDto>>> GetAllLocationsAsPointsAsync()
        {
            try
            {
                // TODO: Add filtering
                var locations = await this.Db.Locations
                    .Include(x => x.Issues)
                    .Include(x => x.Citizens)
                    .Where(x => x.Latitude.HasValue
                             && x.Longitude.HasValue)
                    .ToListAsync();
                var pointDtos = locations.Select(LocationFactory.Point);
                return Result<IEnumerable<PointDto>>.Success(pointDtos);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Get All Locations as Points method.");
                return Result<IEnumerable<PointDto>>.Failure("Error in Get All Locations as Points method.");
            }
        }

        /// <summary>
        /// Creates new location from AddressDto.
        /// </summary>
        /// <param name="model">AddressDto</param>
        /// <returns></returns>
        public async Task<ResultBase> CreateAsync(AddressDto model)
        {
            try
            {
                if (model == null)
                {
                    return ResultBase.Failure("Model is empty.");
                }

                var state = await this.Db.States.SingleOrDefaultAsync(x => x.Id == model.StateId);
                if (state == null)
                {
                    return ResultBase.Failure("State not found. State is required to create a new address location.");
                }

                var location = new Location(model);
                this.Db.Locations.Add(location);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (ArgumentException argumentException)
            {
                return ResultBase.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Location Create Address method.");
                return ResultBase.Failure($"Error in Location Create Address method.");
            }
        }

        /// <summary>
        /// Creates new location from PointDto.
        /// </summary>
        /// <param name="model">PointDto</param>
        /// <returns></returns>
        public async Task<ResultBase> CreateAsync(PointDto model)
        {
            try
            {
                if (model == null)
                {
                    return ResultBase.Failure("Model is empty.");
                }

                var location = new Location(model);
                this.Db.Locations.Add(location);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (ArgumentException argumentException)
            {
                return ResultBase.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Location Create Point method.");
                return ResultBase.Failure($"Error in Location Create Point method.");
            }
        }

        /// <summary>
        /// Update existing location from AddressDto.
        /// </summary>
        /// <param name="model">AddressDto</param>
        /// <returns></returns>
        public async Task<ResultBase> UpdateAsync(AddressDto model)
        {
            try
            {
                if (model == null)
                {
                    return ResultBase.Failure("Model is empty.");
                }

                var state = await this.Db.States.SingleOrDefaultAsync(x => x.Id == model.StateId);
                if (state == null)
                {
                    return ResultBase.Failure("State not found. State is required to update existing address location.");
                }

                var location = await this.Db.Locations.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (location == null)
                {
                    return ResultBase.Failure("Location not found.");
                }

                location.Update(model);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (ArgumentException argumentException)
            {
                return ResultBase.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Location Update AddressDto method.");
                return ResultBase.Failure($"Error in Location Update AddressDto method.");
            }
        }

        /// <summary>
        /// Update existing location from PointDto.
        /// </summary>
        /// <param name="model">PointDto</param>
        /// <returns></returns>
        public async Task<ResultBase> UpdateAsync(PointDto model)
        {
            try
            {
                if (model == null)
                {
                    return ResultBase.Failure("Model is empty.");
                }

                var location = await this.Db.Locations.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (location == null)
                {
                    return ResultBase.Failure("Location not found.");
                }

                location.Update(model);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (ArgumentException argumentException)
            {
                return ResultBase.Failure(argumentException.Message);
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Location Update PointDto method.");
                return ResultBase.Failure($"Error in Location Update PointDto method.");
            }
        }

        /// <summary>
        /// Delete existing location.
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

                var issueCount = await this.Db.Issues.Where(x => x.LocationId == id).CountAsync();
                if (issueCount > 0)
                {
                    return ResultBase.Failure($"Location can not be deleted. This location is associated with {issueCount} issues.");
                }

                var citizenCount = await this.Db.Citizens.Where(x => x.LocationId == id).CountAsync();
                if (citizenCount > 0)
                {
                    return ResultBase.Failure($"Location can not be deleted. This location is associated with {citizenCount} citizens.");
                }

                var location = await this.Db.Locations.SingleOrDefaultAsync(x => x.Id == id);
                if (location == null)
                {
                    return ResultBase.Failure("Location not found.");
                }

                this.Db.Locations.Remove(location);
                await this.Db.SaveChangesAsync();
                return ResultBase.Success();
            }
            catch (Exception exception)
            {
                Log.Logger.Error(exception, "Error in Location Delete method.");
                return ResultBase.Failure($"Error in Location Delete method.");
            }
        }


    }
}

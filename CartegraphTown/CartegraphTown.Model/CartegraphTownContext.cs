using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartegraphTown.Model
{
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Reflection;
    using Entity;
    using Entity.Base.Interfaces;

    class CartegraphTownContext : DbContext
    {

        public CartegraphTownContext() : base("name=CartegraphTownContext")
        {
            // Fake user for now.
            this.userId = 101;
        }

        public CartegraphTownContext(int userId) : base("name=CartegraphTownContext")
        {
            this.userId = userId;
        }


        private readonly int userId;

        public virtual DbSet<Citizen> Citizens { get; set; }

        public virtual DbSet<Issue> Issues { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<State> States { get; set; }

        public override int SaveChanges()
        {
            this.TraceEntities();

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.BuildEntityError(dbEx);
                return 0;
            }
        }

        public override async Task<int> SaveChangesAsync()
        {
            this.TraceEntities();

            try
            {
                return await base.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.BuildEntityError(dbEx);
                return 0;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adds all custom entity configurations from this project dynamically
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Automatically updates trace properties
        /// </summary>
        private void TraceEntities()
        {
            //Finds trace entity on interface 
            var addedEntities = this.ChangeTracker.Entries<ITrackCreateEntity>()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity)
                .ToList();

            var editedEntities = this.ChangeTracker.Entries<ITrackedEntity>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .ToList();

            //validate user
            if (addedEntities.Any() || editedEntities.Any())
            {
                if (userId <= 0)
                {
                    throw new ArgumentException("User id is required for create or update.");
                }

                // TODO: Add user table after adding authentication. No users for now.
                //var user = this.Users.FirstOrDefault(x => x.UserId == userId);
                //if (user == null)
                //{
                //    throw new ArgumentException("Valid user is required for create or update.");
                //}
            }

            foreach (var entity in addedEntities)
            {
                entity.CreatedDate = DateTime.UtcNow;
                entity.CreatedBy = userId;
            }

            foreach (var entity in editedEntities)
            {
                entity.UpdatedDate = DateTime.UtcNow;
                entity.UpdatedBy = userId;
            }
        }

        /// <summary>
        /// Builds a more meaningful error from DbEntityValidationException
        /// </summary>
        /// <param name="dbEx"></param>
        private void BuildEntityError(DbEntityValidationException dbEx)
        {
            string errorMessage = string.Empty;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    errorMessage += $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}" +
                                    Environment.NewLine;
                }
            }
            throw new Exception(errorMessage, dbEx);
        }
    }
}

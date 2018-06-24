namespace CartegraphTown.Model
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Entity;

    public interface ICartegraphTownContext
    {
        DbSet<Citizen> Citizens { get; set; }
        DbSet<Issue> Issues { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<State> States { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
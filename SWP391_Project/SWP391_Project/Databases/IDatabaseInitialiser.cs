namespace SWP391_Project.Databases
{
    public interface IDatabaseInitialiser
    {
        Task InitialiseAsync();
        Task SeedAsync();
        Task TrySeedAsync();
    }
}

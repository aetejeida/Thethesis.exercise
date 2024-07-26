using thesis_exercise.model.Models;

namespace thesis_exercise.data.Repositories.Interface
{
    public interface IComputerRepository
    {
        Task<Catologs> GetCatalogs();
        Task<Computer> Create(Computer entity);
        Task<IList<ComputerDetail>> Get(string query);
        Task Update(int computerId, Computer entity);
    }
}

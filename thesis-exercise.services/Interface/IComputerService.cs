using thesis_exercise.model.DTOs;

namespace thesis_exercise.services.Interface
{
    public interface IComputerService
    {
        Task<IList<ComputerDetailDTO>> Get(string query = null);
        Task<ComputerDTO> Create(ComputerDTO model);
        Task<CatalogsDTO> GetCatalogs();

        Task Update(int computerId, ComputerDTO model);
    }
}

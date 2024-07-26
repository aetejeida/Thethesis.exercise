using AutoMapper;
using thesis_exercise.data;
using thesis_exercise.data.Repositories.Interface;
using thesis_exercise.model.DTOs;
using thesis_exercise.model.Models;
using thesis_exercise.services.Interface;

namespace thesis_exercise.services.Implementation
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerRepository _computerRepository;
        private readonly IMapper _mapper;
        public ComputerService(IComputerRepository computerRepository, IMapper mapper)
        {
            _computerRepository = computerRepository;
            _mapper = mapper;
        }
        public async Task<ComputerDTO> Create(ComputerDTO model)
        {
            var domain = _mapper.Map<Computer>(model);
            return _mapper.Map<ComputerDTO>(await _computerRepository.Create(domain));
        }

        public async Task<IList<ComputerDetailDTO>> Get(string query = null)
        {
            var computers = await _computerRepository.Get(query);
            return _mapper.Map<IList<ComputerDetailDTO>>(ReduceComputerList(computers));
        }

        public async Task<CatalogsDTO> GetCatalogs()
        {
            var entities = await _computerRepository.GetCatalogs();
            return _mapper.Map<CatalogsDTO>(entities);
        }

        public async Task Update(int computerId, ComputerDTO model)
        {
            var entity = _mapper.Map<Computer>(model);
            await _computerRepository.Update(computerId, entity);
        }

        private IEnumerable<ComputerDetail> ReduceComputerList(IList<ComputerDetail> computers) 
        {
            var result = computers.GroupBy(g => new { g.ComputerId }).
                                  Select(x => new ComputerDetail
                                  {
                                      ComputerId = x.FirstOrDefault().ComputerId,
                                      DiskSpace = x.FirstOrDefault().DiskSpace,
                                      Memory = x.FirstOrDefault().Memory,
                                      Processor = x.FirstOrDefault().Processor,
                                      UsbPorts = !string.IsNullOrEmpty(x.FirstOrDefault().UsbPorts)
                                                  ? string.Join(", ", x.GroupBy(u => u.UsbPorts).Select(z => $"{z.Count()} X {z.FirstOrDefault().UsbPorts}").ToArray())
                                                  : string.Empty
                                  });
            return result;
        }
    }
}

